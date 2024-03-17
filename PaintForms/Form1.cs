using System.Drawing.Configuration;
using System.Drawing.Imaging;
using System.Text.Json;
using Newtonsoft;
using Newtonsoft.Json;
using System.Windows.Forms;
using System;

namespace PaintForms
{
    public partial class paintForms : Form
    {
        public paintForms()
        {
            InitializeComponent();
            InitializeDraw();
            InitializeColorPicker();
            pb_box.BackColor = Color.LemonChiffon;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        // Stack till penna
        (List<Point> Points, Color Color) currentAction;
        readonly Stack<(List<Point> Points, Color Color)> undo = new Stack<(List<Point> Points, Color Color)>();
        readonly Stack<(List<Point> Points, Color Color)> redo = new Stack<(List<Point> Points, Color Color)>();

        public Color color { get; set; } = Color.Black;

        private bool drawPen = false;
        private bool drawFill = false;
        private bool drawCircle = false;
        private bool drawSquare = false;
        private bool drawRectangle = false;
        private bool drawTriangle = false;

        // Stack till alla shapes
        private Stack<Shape> shapesDraw = new();
        private Stack<Shape> shapesRedo = new();

        private bool drawing = false;
        private Point previousPoint;
        private Bitmap drawingSurface;

        private void pb_box_Click(object sender, EventArgs e)
        {
            var mouse = (MouseEventArgs)e;

            if (drawFill)
            {
                FillBackground();
            }
            else
            {
                if (drawCircle)
                {
                    CircleShape circle = new CircleShape()
                    {
                        Color = this.color,
                        Center = mouse.Location,
                        Radius = 100
                    };
                    shapesDraw.Push(circle);
                    shapesRedo.Clear();
                }
                else if (drawSquare)
                {
                    SquareShape square = new SquareShape()
                    {
                        Color = this.color,
                        Center = mouse.Location,
                        side = 20,
                    };
                    shapesDraw.Push(square);
                    shapesRedo.Clear();
                }
                else if (drawRectangle)
                {
                    RectangleShape rectangle = new RectangleShape()
                    {
                        Color = this.color,
                        Center = mouse.Location,
                        height = 20,
                        width = 50
                    };
                    shapesDraw.Push(rectangle);
                    shapesRedo.Clear();
                }
                else if (drawTriangle)
                {
                    int x = mouse.X;
                    int y = mouse.Y;
                    TriangleShape triangle = new TriangleShape()
                    {
                        Color = this.color,
                        Center = mouse.Location,
                        points = new Point[] {
                        new Point(x + 100, y),
                        new Point(x - 100, y),
                        new Point(x, y - 150)
                    }
                    };
                    shapesDraw.Push(triangle);
                    shapesRedo.Clear();
                }
            }
            pb_box.Refresh();
        }

        private void pb_box_Paint(object sender, PaintEventArgs e)
        {
            foreach (var s in shapesDraw)
            {
                var pen = new Pen(s.Color);

                if (s is CircleShape c)
                {
                    e.Graphics.DrawEllipse(pen,
                        c.Center.X - c.Radius / 2,
                        c.Center.Y - c.Radius / 2,
                        c.Radius,
                        c.Radius);
                }
                else if (s is SquareShape sq)
                {
                    e.Graphics.DrawRectangle(pen,
                        sq.Center.X,
                        sq.Center.Y,
                        sq.side,
                        sq.side);
                }
                else if (s is RectangleShape r)
                {
                    e.Graphics.DrawRectangle(pen,
                        r.Center.X,
                        r.Center.Y,
                        r.width,
                        r.height);
                }
                else if (s is TriangleShape t)
                {
                    e.Graphics.DrawPolygon(pen,
                        t.points);
                }
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            shapesDraw.Clear();
            undo.Clear();
            redo.Clear();
            InitializeDraw();
            pb_box.Refresh();
        }

        private void btn_undo_Click(object sender, EventArgs e)
        {
            SwitchElement(shapesDraw, shapesRedo);

            if (undo.Any())
            {
                var action = undo.Pop();
                redo.Push(action);
                DrawRefresh();
            }
        }

        private void btn_redo_Click(object sender, EventArgs e)
        {
            SwitchElement(shapesRedo, shapesDraw);

            if (redo.Any())
            {
                var action = redo.Pop();
                this.color = action.Color;
                undo.Push(action);
                DrawRefresh();
            }
        }

        // Ångrar / lägger till i redo(shapesDraw) och undo(shapesUndo) stack för shapes
        private void SwitchElement(Stack<Shape> giver, Stack<Shape> reciever)
        {
            if (giver.Any())
            {
                reciever.Push(giver.Pop());
                pb_box.Refresh();
            }
        }

        // Ångrar / lägger till i redo och undo stack för penna
        private void DrawRefresh()
        {
            InitializeDraw();

            using (Graphics g = Graphics.FromImage(drawingSurface))
            {
                foreach (var action in undo)
                {
                    using Pen pen = new Pen(action.Color);
                    if (action.Points.Count > 1)
                    {
                        for (int i = 1; i < action.Points.Count; i++)
                        {
                            g.DrawLine(pen, action.Points[i - 1], action.Points[i]);
                        }
                    }
                }
            }
            pb_box.Invalidate();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            var result = saveFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                var settings = new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.All
                };
                var json = JsonConvert.SerializeObject(shapesDraw, Formatting.Indented, settings);
                File.WriteAllText(saveFileDialog1.FileName, json);
            }
        }

        private void btn_loadfile_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                var file = openFileDialog1.FileName;
                var content = File.ReadAllText(file);

                var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
                shapesDraw = JsonConvert.DeserializeObject<Stack<Shape>>(content, settings);

                pb_box.Refresh();
            }
        }

        private void btn_saveimage_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG (*.png)|*.png|JPEG (*.jpg;*.jpeg)|*.jpeg|BMP (*.bmp)|*.bmp|All files (*.*)|*.*";
            saveFileDialog.DefaultExt = "";
            saveFileDialog.AddExtension = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveToImage(saveFileDialog.FileName);
            }
        }

        private void SaveToImage(string filename)
        {
            if (pb_box == null || pb_box.Width == 0 || pb_box.Height == 0)
            {
                return;
            }

            var bitmap = new Bitmap(pb_box.Width, pb_box.Height);
            pb_box.DrawToBitmap(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));

            ImageFormat format = ImageFormat.Png;
            string extension = Path.GetExtension(filename).ToLowerInvariant();

            switch (extension)
            {
                case ".png":
                    format = ImageFormat.Png;
                    break;
                case ".jpg":
                case ".jpeg":
                    format = ImageFormat.Jpeg;
                    break;
                case ".bmp":
                    format = ImageFormat.Bmp;
                    break;
            }
            bitmap.Save(filename, format);
        }

        private void InitializeDraw()
        {
            drawingSurface = new Bitmap(pb_box.Width, pb_box.Height);
            pb_box.Image = drawingSurface;
        }

        private void pb_box_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && drawPen)
            {
                drawing = true;
                previousPoint = e.Location;
                currentAction = (new List<Point> { e.Location }, this.color);
            }
            if (e.Button == MouseButtons.Left)
            {
                drawing = true;
                previousPoint = e.Location;
                currentAction = (new List<Point> { }, Color.Black);
                currentAction.Points.Add(e.Location);
            }
        }

        private void pb_box_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawing && drawPen)
            {
                using (Graphics g = Graphics.FromImage(drawingSurface))
                {
                    currentAction.Color = this.color;

                    g.DrawLine(new Pen(currentAction.Color), previousPoint, e.Location);
                    currentAction.Points.Add(e.Location);
                }
                pb_box.Refresh();
                previousPoint = e.Location;
            }
        }

        private void pb_box_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && drawing)
            {
                drawing = false;
                if (drawPen)
                {
                    undo.Push(currentAction);
                    redo.Clear();
                }
            }
        }

        private void FillBackground()
        {
            if (drawingSurface == null) return;

            using (Graphics g = Graphics.FromImage(drawingSurface))
            {
                g.Clear(this.color);
            }

            pb_box.Invalidate();
        }

        private Bitmap ColorPickerWindow(int width, int height, int columns)
        {
            var palette = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(palette))
            {
                Color[] colors = [
                    Color.White,
                    Color.Ivory,
                    Color.LemonChiffon,
                    Color.Khaki,
                    Color.Beige,
                    Color.PeachPuff,
                    Color.LightCoral,
                    Color.Coral,
                    Color.Orange,
                    Color.DarkOrange,
                    Color.Brown,
                    Color.SandyBrown,
                    Color.Gold,
                    Color.Yellow,
                    Color.LightGreen,
                    Color.Lime,
                    Color.Green,
                    Color.DarkGreen,
                    Color.SeaGreen,
                    Color.Olive,
                    Color.Teal,
                    Color.Cyan,
                    Color.Aqua,
                    Color.SkyBlue,
                    Color.LightBlue,
                    Color.Blue,
                    Color.Navy,
                    Color.MidnightBlue,
                    Color.Indigo,
                    Color.DarkViolet,
                    Color.Purple,
                    Color.Orchid,
                    Color.Magenta,
                    Color.DeepPink,
                    Color.Pink,
                    Color.LightPink,
                    Color.Lavender,
                    Color.LavenderBlush,
                    Color.Thistle,
                    Color.Gray,
                    Color.DarkGray,
                    Color.Silver,
                    Color.Black,
                    Color.MintCream,
                    Color.Turquoise,
                    Color.DarkBlue,
                    Color.Orchid,
                    Color.Silver,
                ];

                int rows = (int)Math.Ceiling(colors.Length / (double)columns);
                int cellWidth = width / columns;
                int cellHeight = height / rows;

                for (int i = 0; i < colors.Length; i++)
                {
                    int row = i / columns;
                    int column = i % columns;
                    var brush = new SolidBrush(colors[i]);
                    g.FillRectangle(brush, column * cellWidth, row * cellHeight, cellWidth, cellHeight);
                }
            }
            return palette;
        }

        private void InitializeColorPicker()
        {
            int columns = 8;

            color_picker_box.Image = ColorPickerWindow(color_picker_box.Width, color_picker_box.Height, columns);
        }

        private void color_picker_box_MouseClick(object sender, MouseEventArgs e)
        {
            if (color_picker_box.Image is Bitmap palette)
            {
                Color clickedColor = palette.GetPixel(e.X, e.Y);
                this.color = clickedColor;

                pnl_current_color.BackColor = clickedColor;
            }
        }

        private void btn_color_picker_Click(object sender, EventArgs e)
        {
            ColorDialog colorPickerDialog = new ColorDialog();
            if (colorPickerDialog.ShowDialog() == DialogResult.OK)
            {
                this.color = colorPickerDialog.Color;
                pnl_current_color.BackColor = colorPickerDialog.Color;
            }
        }

        private void btn_pen_Click(object sender, EventArgs e)
        {
            drawPen = !drawPen;

            if (drawPen)
            {
                color = this.color;
                pb_box.Cursor = Cursors.Cross;
                btn_pen.BackColor = Color.LightSkyBlue;

                btn_fill.BackColor = SystemColors.Control;
                btn_circle.BackColor = SystemColors.Control;
                btn_triangle.BackColor = SystemColors.Control;
                btn_rectangle.BackColor = SystemColors.Control;
                btn_square.BackColor = SystemColors.Control;

                drawFill = false;
                drawCircle = false;
                drawSquare = false;
                drawRectangle = false;
                drawTriangle = false;
            }
            else
            {
                drawPen = false;
                pb_box.Cursor = Cursors.Default;
                btn_pen.BackColor = SystemColors.Control;
            }
        }

        private void btn_fill_Click(object sender, EventArgs e)
        {
            drawFill = !drawFill;

            if (drawFill)
            {
                btn_fill.BackColor = Color.LightSkyBlue;
                pb_box.Cursor = Cursors.Cross;

                btn_pen.BackColor = SystemColors.Control;
                btn_circle.BackColor = SystemColors.Control;
                btn_triangle.BackColor = SystemColors.Control;
                btn_rectangle.BackColor = SystemColors.Control;
                btn_square.BackColor = SystemColors.Control;

                drawPen = false;
                drawCircle = false;
                drawSquare = false;
                drawRectangle = false;
                drawTriangle = false;
            }
            else
            {
                drawFill = false;
                pb_box.Cursor = Cursors.Default;
                btn_fill.BackColor = SystemColors.Control;
            }
        }

        private void btn_circle_Click_1(object sender, EventArgs e)
        {
            drawCircle = !drawCircle;

            if (drawCircle)
            {
                color = this.color;
                pb_box.Cursor = Cursors.Cross;
                btn_circle.BackColor = Color.LightSkyBlue;

                btn_pen.BackColor = SystemColors.Control;
                btn_fill.BackColor = SystemColors.Control;
                btn_triangle.BackColor = SystemColors.Control;
                btn_rectangle.BackColor = SystemColors.Control;
                btn_square.BackColor = SystemColors.Control;

                drawPen = false;
                drawFill = false;
                drawSquare = false;
                drawRectangle = false;
                drawTriangle = false;
            }
            else
            {
                drawCircle = false;
                pb_box.Cursor = Cursors.Default;
                btn_circle.BackColor = SystemColors.Control;
            }
        }

        private void btn_square_Click(object sender, EventArgs e)
        {
            drawSquare = !drawSquare;

            if (drawSquare)
            {
                color = this.color;
                pb_box.Cursor = Cursors.Cross;
                btn_square.BackColor = Color.LightSkyBlue;

                btn_pen.BackColor = SystemColors.Control;
                btn_fill.BackColor = SystemColors.Control;
                btn_circle.BackColor = SystemColors.Control;
                btn_triangle.BackColor = SystemColors.Control;
                btn_rectangle.BackColor = SystemColors.Control;

                drawPen = false;
                drawFill = false;
                drawCircle = false;
                drawRectangle = false;
                drawTriangle = false;
            }
            else
            {
                drawSquare = false;
                pb_box.Cursor = Cursors.Default;
                btn_square.BackColor = SystemColors.Control;
            }
        }

        private void btn_rectangle_Click(object sender, EventArgs e)
        {
            drawRectangle = !drawRectangle;

            if (drawRectangle)
            {
                color = this.color;
                pb_box.Cursor = Cursors.Cross;
                btn_rectangle.BackColor = Color.LightSkyBlue;

                btn_pen.BackColor = SystemColors.Control;
                btn_fill.BackColor = SystemColors.Control;
                btn_circle.BackColor = SystemColors.Control;
                btn_triangle.BackColor = SystemColors.Control;
                btn_square.BackColor = SystemColors.Control;

                drawPen = false;
                drawFill = false;
                drawCircle = false;
                drawSquare = false;
                drawTriangle = false;
            }
            else
            {
                drawRectangle = false;
                pb_box.Cursor = Cursors.Default;
                btn_square.BackColor = SystemColors.Control;
            }
        }

        private void btn_triangle_Click(object sender, EventArgs e)
        {
            drawTriangle = !drawTriangle;

            if (drawTriangle)
            {
                color = this.color;
                pb_box.Cursor = Cursors.Cross;
                btn_triangle.BackColor = Color.LightSkyBlue;

                btn_pen.BackColor = SystemColors.Control;
                btn_fill.BackColor = SystemColors.Control;
                btn_circle.BackColor = SystemColors.Control;
                btn_rectangle.BackColor = SystemColors.Control;
                btn_square.BackColor = SystemColors.Control;

                drawPen = false;
                drawFill = false;
                drawCircle = false;
                drawSquare = false;
                drawRectangle = false;
            }
            else
            {
                drawTriangle = false;
                pb_box.Cursor = Cursors.Default;
                btn_square.BackColor = SystemColors.Control;
            }
        }
    }
}