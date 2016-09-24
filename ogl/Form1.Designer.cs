namespace OGL
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.oglWin = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.выборТекстурыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузкаТекстурыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выборОбластиНаложенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.головаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.телоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ногиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.рукиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.параметрыТекстурыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gLTEXTUREMINFILTERToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gLNEARESTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gLLINEARToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gLTEXTUREMAGFILTERToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gLNEARESTToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gLLINEARToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gLTEXTUREWRAPSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gLREPEATToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gLCLAMPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gLTEXTUREWRAPTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gLREPEATToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gLCLAMPToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gLTEXTUREENVMODEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gLMODULATEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gLREPLACEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.способНанесенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.texCoordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.glTexGenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.параметрыGlTexGenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gLTEXTUREGENMODEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gLOBJECTLINEARToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gLEYELINEARToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gLSPHEREMAPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.источникиОсвещенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вклВыклToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // oglWin
            // 
            this.oglWin.AccumBits = ((byte)(0));
            this.oglWin.AutoCheckErrors = false;
            this.oglWin.AutoFinish = false;
            this.oglWin.AutoMakeCurrent = true;
            this.oglWin.AutoSwapBuffers = true;
            this.oglWin.BackColor = System.Drawing.Color.Black;
            this.oglWin.ColorBits = ((byte)(32));
            this.oglWin.DepthBits = ((byte)(16));
            this.oglWin.Location = new System.Drawing.Point(0, 25);
            this.oglWin.Name = "oglWin";
            this.oglWin.Size = new System.Drawing.Size(774, 363);
            this.oglWin.StencilBits = ((byte)(0));
            this.oglWin.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выборТекстурыToolStripMenuItem,
            this.источникиОсвещенияToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(773, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // выборТекстурыToolStripMenuItem
            // 
            this.выборТекстурыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузкаТекстурыToolStripMenuItem,
            this.выборОбластиНаложенияToolStripMenuItem,
            this.параметрыТекстурыToolStripMenuItem,
            this.способНанесенияToolStripMenuItem,
            this.параметрыGlTexGenToolStripMenuItem});
            this.выборТекстурыToolStripMenuItem.Name = "выборТекстурыToolStripMenuItem";
            this.выборТекстурыToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.выборТекстурыToolStripMenuItem.Text = " Текстуры";
            // 
            // загрузкаТекстурыToolStripMenuItem
            // 
            this.загрузкаТекстурыToolStripMenuItem.Name = "загрузкаТекстурыToolStripMenuItem";
            this.загрузкаТекстурыToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.загрузкаТекстурыToolStripMenuItem.Text = "Загрузка текстуры";
            this.загрузкаТекстурыToolStripMenuItem.Click += new System.EventHandler(this.загрузкаТекстурыToolStripMenuItem_Click);
            // 
            // выборОбластиНаложенияToolStripMenuItem
            // 
            this.выборОбластиНаложенияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.головаToolStripMenuItem,
            this.телоToolStripMenuItem,
            this.ногиToolStripMenuItem,
            this.рукиToolStripMenuItem});
            this.выборОбластиНаложенияToolStripMenuItem.Name = "выборОбластиНаложенияToolStripMenuItem";
            this.выборОбластиНаложенияToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.выборОбластиНаложенияToolStripMenuItem.Text = "Выбор области наложения";
            // 
            // головаToolStripMenuItem
            // 
            this.головаToolStripMenuItem.Name = "головаToolStripMenuItem";
            this.головаToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.головаToolStripMenuItem.Text = "Голова";
            this.головаToolStripMenuItem.Click += new System.EventHandler(this.головаToolStripMenuItem_Click);
            // 
            // телоToolStripMenuItem
            // 
            this.телоToolStripMenuItem.Name = "телоToolStripMenuItem";
            this.телоToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.телоToolStripMenuItem.Text = "Тело";
            this.телоToolStripMenuItem.Click += new System.EventHandler(this.телоToolStripMenuItem_Click);
            // 
            // ногиToolStripMenuItem
            // 
            this.ногиToolStripMenuItem.Name = "ногиToolStripMenuItem";
            this.ногиToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.ногиToolStripMenuItem.Text = "Ноги";
            this.ногиToolStripMenuItem.Click += new System.EventHandler(this.ногиToolStripMenuItem_Click);
            // 
            // рукиToolStripMenuItem
            // 
            this.рукиToolStripMenuItem.Name = "рукиToolStripMenuItem";
            this.рукиToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.рукиToolStripMenuItem.Text = "Руки";
            this.рукиToolStripMenuItem.Click += new System.EventHandler(this.рукиToolStripMenuItem_Click);
            // 
            // параметрыТекстурыToolStripMenuItem
            // 
            this.параметрыТекстурыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gLTEXTUREMINFILTERToolStripMenuItem,
            this.gLTEXTUREMAGFILTERToolStripMenuItem,
            this.gLTEXTUREWRAPSToolStripMenuItem,
            this.gLTEXTUREWRAPTToolStripMenuItem,
            this.gLTEXTUREENVMODEToolStripMenuItem});
            this.параметрыТекстурыToolStripMenuItem.Name = "параметрыТекстурыToolStripMenuItem";
            this.параметрыТекстурыToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.параметрыТекстурыToolStripMenuItem.Text = "Параметры текстуры";
            // 
            // gLTEXTUREMINFILTERToolStripMenuItem
            // 
            this.gLTEXTUREMINFILTERToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gLNEARESTToolStripMenuItem,
            this.gLLINEARToolStripMenuItem});
            this.gLTEXTUREMINFILTERToolStripMenuItem.Name = "gLTEXTUREMINFILTERToolStripMenuItem";
            this.gLTEXTUREMINFILTERToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.gLTEXTUREMINFILTERToolStripMenuItem.Text = "GL_TEXTURE_MIN_FILTER";
            // 
            // gLNEARESTToolStripMenuItem
            // 
            this.gLNEARESTToolStripMenuItem.Name = "gLNEARESTToolStripMenuItem";
            this.gLNEARESTToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.gLNEARESTToolStripMenuItem.Text = "GL_NEAREST";
            this.gLNEARESTToolStripMenuItem.Click += new System.EventHandler(this.gLNEARESTToolStripMenuItem_Click);
            // 
            // gLLINEARToolStripMenuItem
            // 
            this.gLLINEARToolStripMenuItem.Name = "gLLINEARToolStripMenuItem";
            this.gLLINEARToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.gLLINEARToolStripMenuItem.Text = "GL_LINEAR";
            this.gLLINEARToolStripMenuItem.Click += new System.EventHandler(this.gLLINEARToolStripMenuItem_Click);
            // 
            // gLTEXTUREMAGFILTERToolStripMenuItem
            // 
            this.gLTEXTUREMAGFILTERToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gLNEARESTToolStripMenuItem1,
            this.gLLINEARToolStripMenuItem1});
            this.gLTEXTUREMAGFILTERToolStripMenuItem.Name = "gLTEXTUREMAGFILTERToolStripMenuItem";
            this.gLTEXTUREMAGFILTERToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.gLTEXTUREMAGFILTERToolStripMenuItem.Text = "GL_TEXTURE_MAG_FILTER";
            // 
            // gLNEARESTToolStripMenuItem1
            // 
            this.gLNEARESTToolStripMenuItem1.Name = "gLNEARESTToolStripMenuItem1";
            this.gLNEARESTToolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.gLNEARESTToolStripMenuItem1.Text = "GL_NEAREST";
            this.gLNEARESTToolStripMenuItem1.Click += new System.EventHandler(this.gLNEARESTToolStripMenuItem1_Click);
            // 
            // gLLINEARToolStripMenuItem1
            // 
            this.gLLINEARToolStripMenuItem1.Name = "gLLINEARToolStripMenuItem1";
            this.gLLINEARToolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.gLLINEARToolStripMenuItem1.Text = "GL_LINEAR";
            this.gLLINEARToolStripMenuItem1.Click += new System.EventHandler(this.gLLINEARToolStripMenuItem1_Click);
            // 
            // gLTEXTUREWRAPSToolStripMenuItem
            // 
            this.gLTEXTUREWRAPSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gLREPEATToolStripMenuItem,
            this.gLCLAMPToolStripMenuItem});
            this.gLTEXTUREWRAPSToolStripMenuItem.Name = "gLTEXTUREWRAPSToolStripMenuItem";
            this.gLTEXTUREWRAPSToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.gLTEXTUREWRAPSToolStripMenuItem.Text = "GL_TEXTURE_WRAP_S";
            // 
            // gLREPEATToolStripMenuItem
            // 
            this.gLREPEATToolStripMenuItem.Name = "gLREPEATToolStripMenuItem";
            this.gLREPEATToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.gLREPEATToolStripMenuItem.Text = "GL_ REPEAT";
            this.gLREPEATToolStripMenuItem.Click += new System.EventHandler(this.gLREPEATToolStripMenuItem_Click);
            // 
            // gLCLAMPToolStripMenuItem
            // 
            this.gLCLAMPToolStripMenuItem.Name = "gLCLAMPToolStripMenuItem";
            this.gLCLAMPToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.gLCLAMPToolStripMenuItem.Text = "GL_CLAMP";
            this.gLCLAMPToolStripMenuItem.Click += new System.EventHandler(this.gLCLAMPToolStripMenuItem_Click);
            // 
            // gLTEXTUREWRAPTToolStripMenuItem
            // 
            this.gLTEXTUREWRAPTToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gLREPEATToolStripMenuItem1,
            this.gLCLAMPToolStripMenuItem1});
            this.gLTEXTUREWRAPTToolStripMenuItem.Name = "gLTEXTUREWRAPTToolStripMenuItem";
            this.gLTEXTUREWRAPTToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.gLTEXTUREWRAPTToolStripMenuItem.Text = "GL_TEXTURE_WRAP_T";
            // 
            // gLREPEATToolStripMenuItem1
            // 
            this.gLREPEATToolStripMenuItem1.Name = "gLREPEATToolStripMenuItem1";
            this.gLREPEATToolStripMenuItem1.Size = new System.Drawing.Size(144, 22);
            this.gLREPEATToolStripMenuItem1.Text = "GL_ REPEAT";
            this.gLREPEATToolStripMenuItem1.Click += new System.EventHandler(this.gLREPEATToolStripMenuItem1_Click);
            // 
            // gLCLAMPToolStripMenuItem1
            // 
            this.gLCLAMPToolStripMenuItem1.Name = "gLCLAMPToolStripMenuItem1";
            this.gLCLAMPToolStripMenuItem1.Size = new System.Drawing.Size(144, 22);
            this.gLCLAMPToolStripMenuItem1.Text = "GL_CLAMP";
            this.gLCLAMPToolStripMenuItem1.Click += new System.EventHandler(this.gLCLAMPToolStripMenuItem1_Click);
            // 
            // gLTEXTUREENVMODEToolStripMenuItem
            // 
            this.gLTEXTUREENVMODEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gLMODULATEToolStripMenuItem,
            this.gLREPLACEToolStripMenuItem});
            this.gLTEXTUREENVMODEToolStripMenuItem.Name = "gLTEXTUREENVMODEToolStripMenuItem";
            this.gLTEXTUREENVMODEToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.gLTEXTUREENVMODEToolStripMenuItem.Text = "GL_TEXTURE_ENV_MODE";
            // 
            // gLMODULATEToolStripMenuItem
            // 
            this.gLMODULATEToolStripMenuItem.Name = "gLMODULATEToolStripMenuItem";
            this.gLMODULATEToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.gLMODULATEToolStripMenuItem.Text = "GL_MODULATE";
            this.gLMODULATEToolStripMenuItem.Click += new System.EventHandler(this.gLMODULATEToolStripMenuItem_Click);
            // 
            // gLREPLACEToolStripMenuItem
            // 
            this.gLREPLACEToolStripMenuItem.Name = "gLREPLACEToolStripMenuItem";
            this.gLREPLACEToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.gLREPLACEToolStripMenuItem.Text = "GL_REPLACE";
            this.gLREPLACEToolStripMenuItem.Click += new System.EventHandler(this.gLREPLACEToolStripMenuItem_Click);
            // 
            // способНанесенияToolStripMenuItem
            // 
            this.способНанесенияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.texCoordToolStripMenuItem,
            this.glTexGenToolStripMenuItem});
            this.способНанесенияToolStripMenuItem.Name = "способНанесенияToolStripMenuItem";
            this.способНанесенияToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.способНанесенияToolStripMenuItem.Text = "Способ нанесения";
            // 
            // texCoordToolStripMenuItem
            // 
            this.texCoordToolStripMenuItem.Name = "texCoordToolStripMenuItem";
            this.texCoordToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.texCoordToolStripMenuItem.Text = "glTexCoord";
            this.texCoordToolStripMenuItem.Click += new System.EventHandler(this.texCoordToolStripMenuItem_Click);
            // 
            // glTexGenToolStripMenuItem
            // 
            this.glTexGenToolStripMenuItem.Name = "glTexGenToolStripMenuItem";
            this.glTexGenToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.glTexGenToolStripMenuItem.Text = "glTexGen";
            this.glTexGenToolStripMenuItem.Click += new System.EventHandler(this.glTexGenToolStripMenuItem_Click);
            // 
            // параметрыGlTexGenToolStripMenuItem
            // 
            this.параметрыGlTexGenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gLTEXTUREGENMODEToolStripMenuItem});
            this.параметрыGlTexGenToolStripMenuItem.Name = "параметрыGlTexGenToolStripMenuItem";
            this.параметрыGlTexGenToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.параметрыGlTexGenToolStripMenuItem.Text = "Параметры glTexGen";
            // 
            // gLTEXTUREGENMODEToolStripMenuItem
            // 
            this.gLTEXTUREGENMODEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gLOBJECTLINEARToolStripMenuItem,
            this.gLEYELINEARToolStripMenuItem,
            this.gLSPHEREMAPToolStripMenuItem});
            this.gLTEXTUREGENMODEToolStripMenuItem.Name = "gLTEXTUREGENMODEToolStripMenuItem";
            this.gLTEXTUREGENMODEToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.gLTEXTUREGENMODEToolStripMenuItem.Text = "GL_TEXTURE_GEN_MODE";
            // 
            // gLOBJECTLINEARToolStripMenuItem
            // 
            this.gLOBJECTLINEARToolStripMenuItem.Name = "gLOBJECTLINEARToolStripMenuItem";
            this.gLOBJECTLINEARToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.gLOBJECTLINEARToolStripMenuItem.Text = "GL_OBJECT_LINEAR";
            this.gLOBJECTLINEARToolStripMenuItem.Click += new System.EventHandler(this.gLOBJECTLINEARToolStripMenuItem_Click);
            // 
            // gLEYELINEARToolStripMenuItem
            // 
            this.gLEYELINEARToolStripMenuItem.Name = "gLEYELINEARToolStripMenuItem";
            this.gLEYELINEARToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.gLEYELINEARToolStripMenuItem.Text = "GL_EYE_LINEAR";
            this.gLEYELINEARToolStripMenuItem.Click += new System.EventHandler(this.gLEYELINEARToolStripMenuItem_Click);
            // 
            // gLSPHEREMAPToolStripMenuItem
            // 
            this.gLSPHEREMAPToolStripMenuItem.Name = "gLSPHEREMAPToolStripMenuItem";
            this.gLSPHEREMAPToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.gLSPHEREMAPToolStripMenuItem.Text = "GL_SPHERE_MAP";
            this.gLSPHEREMAPToolStripMenuItem.Click += new System.EventHandler(this.gLSPHEREMAPToolStripMenuItem_Click);
            // 
            // источникиОсвещенияToolStripMenuItem
            // 
            this.источникиОсвещенияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вклВыклToolStripMenuItem});
            this.источникиОсвещенияToolStripMenuItem.Name = "источникиОсвещенияToolStripMenuItem";
            this.источникиОсвещенияToolStripMenuItem.Size = new System.Drawing.Size(132, 20);
            this.источникиОсвещенияToolStripMenuItem.Text = "Источники освещения";
            // 
            // вклВыклToolStripMenuItem
            // 
            this.вклВыклToolStripMenuItem.Name = "вклВыклToolStripMenuItem";
            this.вклВыклToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.вклВыклToolStripMenuItem.Text = "Вкл/Выкл";
            this.вклВыклToolStripMenuItem.Click += new System.EventHandler(this.вклВыклToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(773, 388);
            this.Controls.Add(this.oglWin);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Лабораторная работа №3";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl oglWin;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem выборТекстурыToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem загрузкаТекстурыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выборОбластиНаложенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem головаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem телоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ногиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem рукиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem параметрыТекстурыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gLTEXTUREMINFILTERToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gLTEXTUREMAGFILTERToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gLTEXTUREWRAPSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gLTEXTUREWRAPTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gLNEARESTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gLLINEARToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gLNEARESTToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem gLLINEARToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem gLREPEATToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gLCLAMPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gLREPEATToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem gLCLAMPToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem gLTEXTUREENVMODEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gLMODULATEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gLREPLACEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem способНанесенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem texCoordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem glTexGenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem параметрыGlTexGenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gLTEXTUREGENMODEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gLOBJECTLINEARToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gLEYELINEARToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gLSPHEREMAPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem источникиОсвещенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вклВыклToolStripMenuItem;
    }
}

