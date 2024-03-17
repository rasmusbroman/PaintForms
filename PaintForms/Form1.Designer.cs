namespace PaintForms
{
    partial class paintForms
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pb_box = new PictureBox();
            btn_Clear = new Button();
            btn_save = new Button();
            saveFileDialog1 = new SaveFileDialog();
            btn_undo = new Button();
            btn_redo = new Button();
            openFileDialog1 = new OpenFileDialog();
            btn_loadfile = new Button();
            btn_saveimage = new Button();
            btn_pen = new Button();
            btn_fill = new Button();
            color_picker_box = new PictureBox();
            pnl_current_color = new Panel();
            colorPicker = new ColorDialog();
            btn_color_picker = new Button();
            btn_circle = new Button();
            btn_square = new Button();
            btn_rectangle = new Button();
            btn_triangle = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pb_box).BeginInit();
            ((System.ComponentModel.ISupportInitialize)color_picker_box).BeginInit();
            SuspendLayout();
            // 
            // pb_box
            // 
            pb_box.BorderStyle = BorderStyle.Fixed3D;
            pb_box.Location = new Point(201, 11);
            pb_box.Margin = new Padding(2);
            pb_box.Name = "pb_box";
            pb_box.Size = new Size(1011, 720);
            pb_box.TabIndex = 0;
            pb_box.TabStop = false;
            pb_box.Click += pb_box_Click;
            pb_box.Paint += pb_box_Paint;
            pb_box.MouseDown += pb_box_MouseDown;
            pb_box.MouseMove += pb_box_MouseMove;
            pb_box.MouseUp += pb_box_MouseUp;
            // 
            // btn_Clear
            // 
            btn_Clear.BackgroundImage = Properties.Resources.clear_icon;
            btn_Clear.BackgroundImageLayout = ImageLayout.Stretch;
            btn_Clear.Location = new Point(79, 184);
            btn_Clear.Margin = new Padding(2);
            btn_Clear.Name = "btn_Clear";
            btn_Clear.Size = new Size(38, 38);
            btn_Clear.TabIndex = 2;
            btn_Clear.UseVisualStyleBackColor = true;
            btn_Clear.Click += btn_Clear_Click;
            // 
            // btn_save
            // 
            btn_save.BackgroundImage = Properties.Resources.save_icon;
            btn_save.BackgroundImageLayout = ImageLayout.Stretch;
            btn_save.Location = new Point(54, 11);
            btn_save.Margin = new Padding(2);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(38, 38);
            btn_save.TabIndex = 7;
            btn_save.UseVisualStyleBackColor = true;
            btn_save.Click += btn_save_Click;
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.DefaultExt = "syn";
            saveFileDialog1.FileName = "shapes2.syn";
            saveFileDialog1.Filter = "Shape YrkesskolaN|*.syn|Alla filer|*.*";
            // 
            // btn_undo
            // 
            btn_undo.BackgroundImage = Properties.Resources.undo_icon;
            btn_undo.BackgroundImageLayout = ImageLayout.Stretch;
            btn_undo.Location = new Point(54, 131);
            btn_undo.Margin = new Padding(2);
            btn_undo.Name = "btn_undo";
            btn_undo.Size = new Size(38, 38);
            btn_undo.TabIndex = 8;
            btn_undo.UseVisualStyleBackColor = true;
            btn_undo.Click += btn_undo_Click;
            // 
            // btn_redo
            // 
            btn_redo.BackgroundImage = Properties.Resources.redo_icon;
            btn_redo.BackgroundImageLayout = ImageLayout.Stretch;
            btn_redo.Location = new Point(109, 131);
            btn_redo.Margin = new Padding(2);
            btn_redo.Name = "btn_redo";
            btn_redo.Size = new Size(38, 38);
            btn_redo.TabIndex = 9;
            btn_redo.UseVisualStyleBackColor = true;
            btn_redo.Click += btn_redo_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn_loadfile
            // 
            btn_loadfile.BackgroundImage = Properties.Resources.load_icon;
            btn_loadfile.BackgroundImageLayout = ImageLayout.Stretch;
            btn_loadfile.Location = new Point(109, 11);
            btn_loadfile.Margin = new Padding(2);
            btn_loadfile.Name = "btn_loadfile";
            btn_loadfile.Size = new Size(38, 38);
            btn_loadfile.TabIndex = 10;
            btn_loadfile.UseVisualStyleBackColor = true;
            btn_loadfile.Click += btn_loadfile_Click;
            // 
            // btn_saveimage
            // 
            btn_saveimage.BackgroundImage = Properties.Resources.save_as_image_icon;
            btn_saveimage.BackgroundImageLayout = ImageLayout.Stretch;
            btn_saveimage.Location = new Point(26, 64);
            btn_saveimage.Margin = new Padding(2);
            btn_saveimage.Name = "btn_saveimage";
            btn_saveimage.Size = new Size(38, 38);
            btn_saveimage.TabIndex = 11;
            btn_saveimage.UseVisualStyleBackColor = true;
            btn_saveimage.Click += btn_saveimage_Click;
            // 
            // btn_pen
            // 
            btn_pen.BackgroundImage = Properties.Resources.pen_icon;
            btn_pen.BackgroundImageLayout = ImageLayout.Stretch;
            btn_pen.Location = new Point(54, 423);
            btn_pen.Name = "btn_pen";
            btn_pen.Size = new Size(38, 38);
            btn_pen.TabIndex = 12;
            btn_pen.UseVisualStyleBackColor = true;
            btn_pen.Click += btn_pen_Click;
            // 
            // btn_fill
            // 
            btn_fill.BackgroundImage = Properties.Resources.fill_icon;
            btn_fill.BackgroundImageLayout = ImageLayout.Stretch;
            btn_fill.Location = new Point(109, 423);
            btn_fill.Name = "btn_fill";
            btn_fill.Size = new Size(38, 38);
            btn_fill.TabIndex = 13;
            btn_fill.UseVisualStyleBackColor = true;
            btn_fill.Click += btn_fill_Click;
            // 
            // color_picker_box
            // 
            color_picker_box.BorderStyle = BorderStyle.Fixed3D;
            color_picker_box.Location = new Point(11, 588);
            color_picker_box.Name = "color_picker_box";
            color_picker_box.Size = new Size(177, 142);
            color_picker_box.TabIndex = 14;
            color_picker_box.TabStop = false;
            color_picker_box.MouseClick += color_picker_box_MouseClick;
            // 
            // pnl_current_color
            // 
            pnl_current_color.BorderStyle = BorderStyle.Fixed3D;
            pnl_current_color.Location = new Point(109, 504);
            pnl_current_color.Name = "pnl_current_color";
            pnl_current_color.Size = new Size(66, 66);
            pnl_current_color.TabIndex = 16;
            // 
            // btn_color_picker
            // 
            btn_color_picker.BackgroundImage = Properties.Resources.color_picker_icon;
            btn_color_picker.BackgroundImageLayout = ImageLayout.Stretch;
            btn_color_picker.Location = new Point(26, 504);
            btn_color_picker.Name = "btn_color_picker";
            btn_color_picker.Size = new Size(66, 66);
            btn_color_picker.TabIndex = 17;
            btn_color_picker.UseVisualStyleBackColor = true;
            btn_color_picker.Click += btn_color_picker_Click;
            // 
            // btn_circle
            // 
            btn_circle.BackgroundImage = Properties.Resources.circle_icon;
            btn_circle.BackgroundImageLayout = ImageLayout.Stretch;
            btn_circle.Location = new Point(54, 276);
            btn_circle.Name = "btn_circle";
            btn_circle.Size = new Size(38, 38);
            btn_circle.TabIndex = 18;
            btn_circle.UseVisualStyleBackColor = true;
            btn_circle.Click += btn_circle_Click_1;
            // 
            // btn_square
            // 
            btn_square.BackgroundImage = Properties.Resources.square_icon;
            btn_square.BackgroundImageLayout = ImageLayout.Stretch;
            btn_square.Location = new Point(54, 320);
            btn_square.Name = "btn_square";
            btn_square.Size = new Size(38, 38);
            btn_square.TabIndex = 19;
            btn_square.UseVisualStyleBackColor = true;
            btn_square.Click += btn_square_Click;
            // 
            // btn_rectangle
            // 
            btn_rectangle.BackgroundImage = Properties.Resources.rectangle_icon;
            btn_rectangle.BackgroundImageLayout = ImageLayout.Stretch;
            btn_rectangle.Location = new Point(109, 320);
            btn_rectangle.Name = "btn_rectangle";
            btn_rectangle.Size = new Size(38, 38);
            btn_rectangle.TabIndex = 20;
            btn_rectangle.UseVisualStyleBackColor = true;
            btn_rectangle.Click += btn_rectangle_Click;
            // 
            // btn_triangle
            // 
            btn_triangle.BackgroundImage = Properties.Resources.triangle_icon;
            btn_triangle.BackgroundImageLayout = ImageLayout.Stretch;
            btn_triangle.Location = new Point(109, 276);
            btn_triangle.Name = "btn_triangle";
            btn_triangle.Size = new Size(38, 38);
            btn_triangle.TabIndex = 21;
            btn_triangle.UseVisualStyleBackColor = true;
            btn_triangle.Click += btn_triangle_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(79, 75);
            label1.Name = "label1";
            label1.Size = new Size(96, 16);
            label1.TabIndex = 22;
            label1.Text = "Save As Image";
            // 
            // paintForms
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1223, 742);
            Controls.Add(label1);
            Controls.Add(btn_triangle);
            Controls.Add(btn_rectangle);
            Controls.Add(btn_square);
            Controls.Add(btn_circle);
            Controls.Add(btn_color_picker);
            Controls.Add(pnl_current_color);
            Controls.Add(color_picker_box);
            Controls.Add(btn_fill);
            Controls.Add(btn_pen);
            Controls.Add(btn_saveimage);
            Controls.Add(btn_loadfile);
            Controls.Add(btn_redo);
            Controls.Add(btn_undo);
            Controls.Add(btn_save);
            Controls.Add(btn_Clear);
            Controls.Add(pb_box);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2);
            Name = "paintForms";
            Text = "PaintForms 3D";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pb_box).EndInit();
            ((System.ComponentModel.ISupportInitialize)color_picker_box).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pb_box;
        private Button btn_Clear;
        private Button btn_save;
        private SaveFileDialog saveFileDialog1;
        private Button btn_undo;
        private Button btn_redo;
        private OpenFileDialog openFileDialog1;
        private Button btn_loadfile;
        private Button btn_saveimage;
        private Button btn_pen;
        private Button btn_fill;
        private PictureBox color_picker_box;
        private Panel pnl_current_color;
        private ColorDialog colorPicker;
        private Button btn_color_picker;
        private Button btn_circle;
        private Button btn_square;
        private Button btn_rectangle;
        private Button btn_triangle;
        private Label label1;
    }
}
