using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;
using Tao.DevIl; // подключаем пространство имен для работы с текстурами

namespace OGL
{
    public partial class Form1 : Form
    {
        public float tx = 0, ty = 0, tz = 0, s = 1, xangle, yangle, zangle = 0, sxangle, syangle, szangle = 0 , df = 2f;
        public float stx = 0, sty = 0, stz = 0, ss = 1;
        public bool napr = false, axis = false;
        public float angle = 0; //переменная для вычисления угла поворота
        public int space = 0; //пространство,объект,детали
        public int head = 1, hand = 2, foot = 3, body = 4;
        public int texturArea = 0;
        public int imageId;
        public uint mGlTextureObject;
        public bool textureIsLoad = false;
        public bool GL_TEXTURE_WRAP_S = false, GL_TEXTURE_WRAP_T = false, GL_TEXTURE_MAG_FILTER = false, GL_TEXTURE_MIN_FILTER = false, GL_TEXTURE_ENV_MODE = false;
        public bool texCoordMethod = true;
        public int GL_TEXTURE_GEN_MODE = 0;

        // для источников--------------------------------------------

        public float[] pointLight1_position = new float[4] { 10, 10, 0, 1 }; // позиция
        public float[] pointLight1_ambient = new float[3] { 1, 0, 0 }; // цвет фонового излучения
        public float[] pointLight1_diffuse = new float[3] { 1, 0, 1 };  // цвет рассеянного излучения
        public float[] pointLight1_specular = new float[4] { 0, 1, 0, 1 }; // цвет зеркального излучения
        public float[] pointLight1_const = new float[3] { 1, 1, 1 }; // коэффициенты затухания

        public float[] pointLight2_position = new float[4] { -10, 10, 0, 1 }; // позиция
        public float[] pointLight2_ambient = new float[3] { 0, 1, 1 }; // цвет фонового излучения
        public float[] pointLight2_diffuse = new float[3] { 0, 1, 1 };  // цвет рассеянного излучения
        public float[] pointLight2_specular = new float[4] { 1, 0, 0, 1 }; // цвет зеркального излучения
        public float[] pointLight2_const = new float[3] { 1, 1, 1 }; // коэффициенты затухания

        public bool light_on = true;
        //-----------------------------------------------------------

        public void drawAxis()
        {       
            Gl.glColor3f(1,1,0); //задание текущего цвета вершины (R,G,B)
            Gl.glLineWidth(3); //высота
            Gl.glBegin(Gl.GL_LINE_STRIP); //каждая след.вершина задает отрезок вместе с предыдущей
            Gl.glVertex3f(-1000.0f, 0.1f, 0.0f);
            Gl.glVertex3f(1000.0f, 0.1f, 0.0f);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_LINE_STRIP);
            Gl.glVertex3f(0.0f, -1000.0f, 0.0f);
            Gl.glVertex3f(0.0f, 1000.0f, 0.0f);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_LINE_STRIP);
            Gl.glVertex3f(0.0f, 0.1f, -1000.0f);
            Gl.glVertex3f(0.0f, 0.1f, 1000.0f);
            Gl.glEnd();            
            
        }

        public void enable_light()
        {
                Gl.glEnable(Gl.GL_LIGHT1);
                Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_DIFFUSE, pointLight1_diffuse);
                Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_POSITION, pointLight1_position);
                Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_AMBIENT, pointLight1_ambient);
                Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_SPECULAR, pointLight1_specular);

                Gl.glEnable(Gl.GL_LIGHT2);
                Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_DIFFUSE, pointLight2_diffuse);
                Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_POSITION, pointLight2_position);
                Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_AMBIENT, pointLight2_ambient);
                Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_SPECULAR, pointLight2_specular);
        }

        public Form1()
        {
            InitializeComponent();
            oglWin.InitializeContexts();
            timer1.Interval = 100;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            this.Resize += new EventHandler(Form1_Resize);
            this.MouseWheel+=new MouseEventHandler(Form1_MouseWheel);
        }

        private void Form1_Load(object sender, EventArgs e) // задание "цвет очистки"
        {
            // инициализация Glut 
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);

            Gl.glEnable(Gl.GL_DEPTH_TEST); //настройка парамтров для визуализации
            Gl.glEnable(Gl.GL_NORMALIZE);
            Gl.glClearColor(1, 1, 1, 1);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);
            Gl.glLightModelf(Gl.GL_LIGHT_MODEL_TWO_SIDE, Gl.GL_TRUE);
            Gl.glEnable(Gl.GL_LIGHT0);
            Gl.glEnable(Gl.GL_LIGHTING);
            
            //-------------------------------------источники света----------------------------------------------
            enable_light();
            //--------------------------------------------------------------------------------------------------

            // инициализация библиотеки openIL 
            Il.ilInit();
            Il.ilEnable(Il.IL_ORIGIN_SET);

            //-------------------------------------------голова---------------------------------------------

            Gl.glNewList(head, Gl.GL_COMPILE);

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glColor3d(0.3, 1, 1);
            /*лицо*/
            Gl.glVertex3f(1.2f, 1.4f, 1.1f);   //лево верх
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3f(0.2f, 1.4f, 1.1f);   //право верх
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3f(0.2f, 0.8f, 1.1f);   //право низ
            Gl.glTexCoord2f(1, 0);
            Gl.glVertex3f(1.2f, 0.8f, 1.1f);   //лево низ
            Gl.glTexCoord2f(0, 0);
            /*лев висок*/
            Gl.glVertex3f(0.2f, 1.4f, 1.1f);   //лево верх
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3f(0.2f, 1.4f, 0.2f);   //право верх
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3f(0.2f, 0.8f, 0.2f);     //право низ
            Gl.glTexCoord2f(1, 0);
            Gl.glVertex3f(0.2f, 0.8f, 1.1f);   //лево низ
            Gl.glTexCoord2f(0, 0);
            /*прав висок*/
            Gl.glVertex3f(1.2f, 1.4f, 1.1f); //лево верх
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3f(1.2f, 1.4f, 0.2f);   //право верх
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3f(1.2f, 0.8f, 0.2f);     //право низ
            Gl.glTexCoord2f(1, 0);
            Gl.glVertex3f(1.2f, 0.8f, 1.1f);   //лево низ
            Gl.glTexCoord2f(0, 0);
            /*мокушка*/
            Gl.glVertex3f(1.2f, 1.4f, 1.1f); //лево верх
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3f(1.2f, 1.4f, 0.2f);   //право верх
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3f(0.2f, 1.4f, 0.2f);     //право низ
            Gl.glTexCoord2f(1, 0);
            Gl.glVertex3f(0.2f, 1.4f, 1.1f);   //лево низ
            Gl.glTexCoord2f(0, 0);
            /*низ*/
            Gl.glVertex3f(1.2f, 0.8f, 0.2f); //лево верх
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3f(0.2f, 0.8f, 0.2f);   //право верх
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3f(0.2f, 0.8f, 1.1f);     //право низ
            Gl.glTexCoord2f(1, 0);
            Gl.glVertex3f(1.2f, 0.8f, 1.1f);   //лево низ
            Gl.glTexCoord2f(0, 0);
            /*затылок*/
            Gl.glVertex3f(1.2f, 1.4f, 0.2f); //лево верх
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3f(0.2f, 1.4f, 0.2f);   //право верх
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3f(0.2f, 0.8f, 0.2f);     //право низ
            Gl.glTexCoord2f(1, 0);
            Gl.glVertex3f(1.2f, 0.8f, 0.2f);   //лево низ
            Gl.glTexCoord2f(0, 0);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_TRIANGLES);
            /*левый глаз*/
            Gl.glColor3d(0, 1, 0);   //Левая вершина
            Gl.glVertex3d(1, 1.05, 1.15);
            Gl.glTexCoord2f(0, 1);
            Gl.glColor3d(0.5, 0.5, 0.5);   //Средняя
            Gl.glTexCoord2f(0, 0);
            Gl.glVertex3d(0.85, 1.15, 1.15);
            Gl.glTexCoord2f(1, 1);
            Gl.glColor3d(1, 1, 1);   //Правая
            Gl.glVertex3d(0.8, 1.05, 1.15);
            /*правый глаз*/
            Gl.glColor3d(0, 1, 0);   //Левая вершина
            Gl.glVertex3d(0.6, 1.05, 1.15);
            Gl.glTexCoord2f(0, 1);
            Gl.glColor3d(0.5, 0.5, 0.5);   //Средняя
            Gl.glTexCoord2f(0, 0);
            Gl.glVertex3d(0.55, 1.15, 1.15);
            Gl.glTexCoord2f(1, 1);
            Gl.glColor3d(1, 1, 1);   //Правая
            Gl.glVertex3d(0.4, 1.05, 1.15);
            /*рот*/
            Gl.glColor3d(0, 0, 0);         //Левая вершина
            Gl.glVertex3d(0.8, 0.9, 1.15);
            Gl.glTexCoord2f(0, 1);
            Gl.glColor3d(0.5, 0.5, 0.5);   //Средняя
            Gl.glTexCoord2f(0, 0);
            Gl.glVertex3d(0.7, 1.05, 1.15);
            Gl.glTexCoord2f(1, 1);
            Gl.glColor3d(1, 1, 1);         //Правая
            Gl.glVertex3d(0.6, 0.9, 1.15);
            Gl.glEnd();

            Gl.glEndList();

            //-----------------------------------------тело-----------------------------------------------

            Gl.glNewList(body, Gl.GL_COMPILE);

            Gl.glBegin(Gl.GL_QUADS);
            /*пузо*/
            Gl.glColor3d(0.5, 0.5, 0.5);
            Gl.glVertex3d(0.9, 0.8, 0.9); //лево верх
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3d(0.5, 0.8, 0.9);   //право верх
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3d(0.5, 0.4, 0.9);     //право низ
            Gl.glTexCoord2f(1, 0);
            Gl.glVertex3d(0.9, 0.4, 0.9);   //лево низ
            Gl.glTexCoord2f(0, 0);
            /*спина*/
            Gl.glColor3d(0.5, 0.5, 0.5);
            Gl.glVertex3d(0.9, 0.8, 0.4); //лево верх
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3d(0.5, 0.8, 0.4);   //право верх
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3d(0.5, 0.4, 0.4);     //право низ
            Gl.glTexCoord2f(1, 0);
            Gl.glVertex3d(0.9, 0.4, 0.4);   //лево низ
            Gl.glTexCoord2f(0, 0);
            /*лев бок*/
            Gl.glColor3d(0.5, 0.5, 0.5);
            Gl.glVertex3d(0.5, 0.8, 0.9); //лево верх
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3d(0.5, 0.8, 0.4);   //право верх
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3d(0.5, 0.4, 0.4);     //право низ
            Gl.glTexCoord2f(1, 0);
            Gl.glVertex3d(0.5, 0.4, 0.9);   //лево низ
            Gl.glTexCoord2f(0, 0);
            /*прав бок*/
            Gl.glColor3d(0.5, 0.5, 0.5);
            Gl.glVertex3d(0.9, 0.8, 0.9); //лево верх
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3d(0.9, 0.8, 0.4);   //право верх
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3d(0.9, 0.4, 0.4);     //право низ
            Gl.glTexCoord2f(1, 0);
            Gl.glVertex3d(0.9, 0.4, 0.9);   //лево низ
            Gl.glTexCoord2f(0, 0);
            /*низ*/
            Gl.glColor3d(0.5, 0.5, 0.5);
            Gl.glVertex3d(0.9, 0.4, 0.4); //лево верх
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3d(0.5, 0.4, 0.4);   //право верх
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3d(0.5, 0.4, 0.9);     //право низ
            Gl.glTexCoord2f(1, 0);
            Gl.glVertex3d(0.9, 0.4, 0.9);   //лево низ
            Gl.glTexCoord2f(0, 0);
            Gl.glEnd();

            Gl.glEndList();

            //-----------------------------------------рука-----------------------------------------------
            
            Gl.glNewList(hand, Gl.GL_COMPILE);

            Gl.glBegin(Gl.GL_QUADS);
            /*верх*/
            Gl.glColor3d(0, 0, 0);
            Gl.glVertex3d(0.1, 0.1, 0.1); //лево верх
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3d(0.1, 0.1, -0.1);   //право верх
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3d(-0.1, 0.1, -0.1);     //право низ
            Gl.glTexCoord2f(1, 0);
            Gl.glVertex3d(-0.1, 0.1, 0.1);   //лево низ
            Gl.glTexCoord2f(0, 0);
            /*низ*/
            Gl.glColor3d(0, 0, 0);
            Gl.glVertex3d(0.1, -0.1, 0.1); //лево верх
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3d(0.1, -0.1, -0.1);   //право верх
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3d(-0.1, -0.1, -0.1);     //право низ
            Gl.glTexCoord2f(1, 0);
            Gl.glVertex3d(-0.1, -0.1, 0.1);   //лево низ
            Gl.glTexCoord2f(0, 0);
            /*перед*/
            Gl.glColor3d(0, 0, 0);
            Gl.glVertex3d(0.1, 0.1, 0.1); //лево верх
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3d(-0.1, 0.1, 0.1);   //право верх
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3d(-0.1, -0.1, 0.1);     //право низ
            Gl.glTexCoord2f(1, 0);
            Gl.glVertex3d(0.1, -0.1, 0.1);   //лево низ
            Gl.glTexCoord2f(0, 0);
            /*зад*/
            Gl.glColor3d(0, 0, 0);
            Gl.glVertex3d(0.1, 0.1, -0.1); //лево верх
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3d(-0.1, 0.1, -0.1);   //право верх
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3d(-0.1, -0.1, -0.1);     //право низ
            Gl.glTexCoord2f(1, 0);
            Gl.glVertex3d(0.1, -0.1, -0.1);   //лево низ
            Gl.glTexCoord2f(0, 0);
            /*лев. бок*/
            Gl.glColor3d(0, 0, 0);
            Gl.glVertex3d(0.1, 0.1, 0.1); //лево верх
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3d(0.1, 0.1, -0.1);   //право верх
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3d(0.1, -0.1, -0.1);     //право низ
            Gl.glTexCoord2f(1, 0);
            Gl.glVertex3d(0.1, -0.1, 0.1);   //лево низ
            Gl.glTexCoord2f(0, 0);
            /*прав.бок*/
            Gl.glColor3d(0, 0, 0);
            Gl.glVertex3d(-0.1, 0.1, 0.1); //лево верх
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3d(-0.1, 0.1, -0.1);   //право верх
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3d(-0.1, -0.1, -0.1);     //право низ
            Gl.glTexCoord2f(1, 0);
            Gl.glVertex3d(-0.1, -0.1, 0.1);   //лево низ
            Gl.glTexCoord2f(0, 0);
            Gl.glEnd();

            Gl.glEndList();

            //-----------------------------------------нога-----------------------------------------------
            Gl.glNewList(foot, Gl.GL_COMPILE);

            Gl.glBegin(Gl.GL_QUADS);
            /*верх*/
            Gl.glColor3d(0, 0, 0);
            Gl.glVertex3d(0.9, 0.4, 0.8); //лево верх
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3d(0.9, 0.4, 0.5);   //право верх
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3d(0.75, 0.4, 0.5);     //право низ
            Gl.glTexCoord2f(1, 0);
            Gl.glVertex3d(0.75, 0.4, 0.8);   //лево низ
            Gl.glTexCoord2f(0, 0);
            /*низ*/
            Gl.glColor3d(0, 0, 0);
            Gl.glVertex3d(0.9, 0.2, 0.8); //лево верх
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3d(0.9, 0.2, 0.5);   //право верх
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3d(0.75, 0.2, 0.5);     //право низ
            Gl.glTexCoord2f(1, 0);
            Gl.glVertex3d(0.75, 0.2, 0.8);   //лево низ
            Gl.glTexCoord2f(0, 0);
            /*перед*/
            Gl.glColor3d(0, 0, 0);
            Gl.glVertex3d(0.9, 0.2, 0.8); //лево верх
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3d(0.9, 0.4, 0.8);   //право верх
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3d(0.75, 0.4, 0.8);     //право низ
            Gl.glTexCoord2f(1, 0);
            Gl.glVertex3d(0.75, 0.2, 0.8);   //лево низ
            Gl.glTexCoord2f(0, 0);
            /*зад*/
            Gl.glColor3d(0, 0, 0);
            Gl.glVertex3d(0.9, 0.2, 0.5); //лево верх
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3d(0.9, 0.4, 0.5);   //право верх
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3d(0.75, 0.4, 0.5);     //право низ
            Gl.glTexCoord2f(1, 0);
            Gl.glVertex3d(0.75, 0.2, 0.5);   //лево низ
            Gl.glTexCoord2f(0, 0);
            /*лев. бок*/
            Gl.glColor3d(0, 0, 0);
            Gl.glVertex3d(0.9, 0.4, 0.8); //лево верх
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3d(0.9, 0.2, 0.8);   //право верх
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3d(0.9, 0.2, 0.5);     //право низ
            Gl.glTexCoord2f(1, 0);
            Gl.glVertex3d(0.9, 0.4, 0.5);   //лево низ
            Gl.glTexCoord2f(0, 0);
            /*прав.бок*/
            Gl.glColor3d(0, 0, 0);
            Gl.glVertex3d(0.75, 0.4, 0.8); //лево верх
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3d(0.75, 0.2, 0.8);   //право верх
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3d(0.75, 0.2, 0.5);     //право низ
            Gl.glTexCoord2f(1, 0);
            Gl.glVertex3d(0.75, 0.4, 0.5);   //лево низ
            Gl.glTexCoord2f(0, 0);
            Gl.glEnd();

            /*------------------------нога-------------------------*/
            Gl.glBegin(Gl.GL_QUADS);
            /*верх*/
            Gl.glColor3d(0, 0, 0);
            Gl.glVertex3d(0.65, 0.4, 0.8); //лево верх
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3d(0.65, 0.4, 0.5);   //право верх
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3d(0.5, 0.4, 0.5);     //право низ
            Gl.glTexCoord2f(1, 0);
            Gl.glVertex3d(0.5, 0.4, 0.8);   //лево низ
            Gl.glTexCoord2f(0, 0);
            /*низ*/
            Gl.glColor3d(0, 0, 0);
            Gl.glVertex3d(0.65, 0.2, 0.8); //лево верх
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3d(0.65, 0.2, 0.5);   //право верх
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3d(0.5, 0.2, 0.5);     //право низ
            Gl.glTexCoord2f(1, 0);
            Gl.glVertex3d(0.5, 0.2, 0.8);   //лево низ
            Gl.glTexCoord2f(0, 0);
            /*перед*/
            Gl.glColor3d(0, 0, 0);
            Gl.glVertex3d(0.65, 0.2, 0.8); //лево верх
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3d(0.65, 0.4, 0.8);   //право верх
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3d(0.5, 0.4, 0.8);     //право низ
            Gl.glTexCoord2f(1, 0);
            Gl.glVertex3d(0.5, 0.2, 0.8);   //лево низ
            Gl.glTexCoord2f(0, 0);
            /*зад*/
            Gl.glColor3d(0, 0, 0);
            Gl.glVertex3d(0.65, 0.2, 0.5); //лево верх
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3d(0.65, 0.4, 0.5);   //право верх
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3d(0.5, 0.4, 0.5);     //право низ
            Gl.glTexCoord2f(1, 0);
            Gl.glVertex3d(0.5, 0.2, 0.5);   //лево низ
            Gl.glTexCoord2f(0, 0);
            /*лев. бок*/
            Gl.glColor3d(0, 0, 0);
            Gl.glVertex3d(0.65, 0.4, 0.8); //лево верх
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3d(0.65, 0.2, 0.8);   //право верх
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3d(0.65, 0.2, 0.5);     //право низ
            Gl.glTexCoord2f(1, 0);
            Gl.glVertex3d(0.65, 0.4, 0.5);   //лево низ
            Gl.glTexCoord2f(0, 0);
            /*прав.бок*/
            Gl.glColor3d(0, 0, 0);
            Gl.glVertex3d(0.5, 0.4, 0.8); //лево верх
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3d(0.5, 0.2, 0.8);   //право верх
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3d(0.5, 0.2, 0.5);     //право низ
            Gl.glTexCoord2f(1, 0);
            Gl.glVertex3d(0.5, 0.4, 0.5);   //лево низ
            Gl.glTexCoord2f(0, 0);
            Gl.glEnd();

            Gl.glEndList(); 

            //---------------------------------------------------------------------------------------------------------


            timer1.Start();
            Redrawing(oglWin, this);
        }

        public void Redrawing(SimpleOpenGlControl wnd, Form frm)
        {
            wnd.Size = frm.Size; 
            Gl.glViewport(0, 0, wnd.Width, wnd.Height); //установка порта вывода в соответствии с размерами элемента
            Gl.glMatrixMode(Gl.GL_PROJECTION); //настройка проекции
            Gl.glLoadIdentity();  //заменяет текущую матрицу на единичную
            Glu.gluPerspective(35, (float)wnd.Width / (float)wnd.Height, 0.1, 5000); //перспективная матрица(задаёт усеченный конус видимости)
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
        }

        public void initTextParam()
        {
            // устанавливаем значение координаты s, если оно не лежит в пределах [0,1]
            if (GL_TEXTURE_WRAP_S)
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_CLAMP);
            else
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT); // по умолчанию

            // устанавливаем значение координаты t, если оно не лежит в пределах [0,1]
            if (GL_TEXTURE_WRAP_T)
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_CLAMP);
            else
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT); // по умолчанию

            // задание функции для растяжения текстуры
            if (GL_TEXTURE_MAG_FILTER)
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_NEAREST);
            else
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR); // по умолчанию

            // задание функции для сжатия текстуры
            if (GL_TEXTURE_MIN_FILTER)
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_NEAREST);
            else
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR); // по умолчанию

            // настройки взаимодействия текстуры с материалом объекта
            if (GL_TEXTURE_ENV_MODE)
                Gl.glTexEnvf(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_MODULATE);
            else
                Gl.glTexEnvf(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_REPLACE);
        }

        public void switch_GL_TEXTURE_GEN_MODE()
        {
            switch (GL_TEXTURE_GEN_MODE)
            {
                case 1:
                    Gl.glTexGeni(Gl.GL_S, Gl.GL_TEXTURE_GEN_MODE, Gl.GL_EYE_LINEAR);
                    Gl.glTexGeni(Gl.GL_T, Gl.GL_TEXTURE_GEN_MODE, Gl.GL_EYE_LINEAR);
                    break;
                case 2:
                    Gl.glTexGeni(Gl.GL_S, Gl.GL_TEXTURE_GEN_MODE, Gl.GL_SPHERE_MAP);
                    Gl.glTexGeni(Gl.GL_T, Gl.GL_TEXTURE_GEN_MODE, Gl.GL_SPHERE_MAP);
                    break;
                default:
                    Gl.glTexGeni(Gl.GL_S, Gl.GL_TEXTURE_GEN_MODE, Gl.GL_OBJECT_LINEAR);
                    Gl.glTexGeni(Gl.GL_T, Gl.GL_TEXTURE_GEN_MODE, Gl.GL_OBJECT_LINEAR);
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {   


            Gl.glPushMatrix();

            Glu.gluLookAt(6d, 3d, 10d, 0d, 0d, 0d, 0d, 35d, -1d); //изменение положения наблюдателя(точка,центр,вектор)
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            Gl.glTranslated(stx, sty, stz);
            Gl.glRotated(sxangle, 1, 0, 0); //вращение вокруг оси х
            Gl.glRotated(syangle, 0, 1, 0); //вращение вокруг оси у
            Gl.glRotated(szangle, 0, 0, 1); //вращение вокруг оси z
            Gl.glScalef(ss, ss, ss);
         
            if (axis == true)
                drawAxis();

            Gl.glTranslated(tx, ty, tz); //перенос объекта,прибавляя к коо-м его вершин знач-я параметров матрицы
            Gl.glRotated(xangle, 1, 0, 0); //поворот против часовой стрелки на угол angle 
            Gl.glRotated(yangle, 0, 1, 0);
            Gl.glRotated(zangle, 0, 0, 1);
            Gl.glScalef(s, s, s); //масштабирование объекта

            // рисуем
            
            if (light_on)
            {
                enable_light();
            }

            angle += 15;

            if (textureIsLoad)
            {
                if (texCoordMethod)
                {

                    switch (texturArea)
                    {
                        case 1:
                            // включаем режим текстурирования 
                            Gl.glEnable(Gl.GL_TEXTURE_2D);
                            // включаем режим текстурирования , указывая индификатор mGlTextureObject 
                            Gl.glBindTexture(Gl.GL_TEXTURE_2D, mGlTextureObject);

                            Gl.glCallList(head);

                            // отключаем режим текстурирования 
                            Gl.glDisable(Gl.GL_TEXTURE_2D);

                            Gl.glCallList(body);
                            Gl.glCallList(foot);
                            Gl.glTranslated(0.4, 0.6, 0.65);
                            Gl.glRotatef(angle, 1, 0, 0);
                            Gl.glCallList(hand);
                            Gl.glTranslated(0.6, 0, 0);
                            Gl.glCallList(hand);
                            break;
                        case 2:
                            Gl.glCallList(head);

                            // включаем режим текстурирования 
                            Gl.glEnable(Gl.GL_TEXTURE_2D);
                            // включаем режим текстурирования , указывая индификатор mGlTextureObject 
                            Gl.glBindTexture(Gl.GL_TEXTURE_2D, mGlTextureObject);

                            Gl.glCallList(body);

                            // отключаем режим текстурирования 
                            Gl.glDisable(Gl.GL_TEXTURE_2D);

                            Gl.glCallList(foot);
                            Gl.glTranslated(0.4, 0.6, 0.65);
                            Gl.glRotatef(angle, 1, 0, 0);
                            Gl.glCallList(hand);
                            Gl.glTranslated(0.6, 0, 0);
                            Gl.glCallList(hand);

                            break;
                        case 3:
                            Gl.glCallList(head);
                            Gl.glCallList(body);

                            // включаем режим текстурирования 
                            Gl.glEnable(Gl.GL_TEXTURE_2D);
                            // включаем режим текстурирования , указывая индификатор mGlTextureObject 
                            Gl.glBindTexture(Gl.GL_TEXTURE_2D, mGlTextureObject);

                            Gl.glCallList(foot);

                            // отключаем режим текстурирования 
                            Gl.glDisable(Gl.GL_TEXTURE_2D);

                            Gl.glTranslated(0.4, 0.6, 0.65);
                            Gl.glRotatef(angle, 1, 0, 0);
                            Gl.glCallList(hand);
                            Gl.glTranslated(0.6, 0, 0);
                            Gl.glCallList(hand);
                            break;
                        case 4:
                            Gl.glCallList(head);
                            Gl.glCallList(body);
                            Gl.glCallList(foot);
                            Gl.glTranslated(0.4, 0.6, 0.65);
                            Gl.glRotatef(angle, 1, 0, 0);
                            // включаем режим текстурирования 
                            Gl.glEnable(Gl.GL_TEXTURE_2D);
                            // включаем режим текстурирования , указывая индификатор mGlTextureObject 
                            Gl.glBindTexture(Gl.GL_TEXTURE_2D, mGlTextureObject);
                            Gl.glCallList(hand);
                            Gl.glTranslated(0.6, 0, 0);
                            Gl.glCallList(hand);
                            // отключаем режим текстурирования 
                            Gl.glDisable(Gl.GL_TEXTURE_2D);
                            break;
                        default:
                            // включаем режим текстурирования 
                            Gl.glEnable(Gl.GL_TEXTURE_2D);
                            // включаем режим текстурирования , указывая индификатор mGlTextureObject 
                            Gl.glBindTexture(Gl.GL_TEXTURE_2D, mGlTextureObject);
                            Gl.glCallList(head);
                            Gl.glCallList(body);
                            Gl.glCallList(foot);
                            Gl.glTranslated(0.4, 0.6, 0.65);
                            Gl.glRotatef(angle, 1, 0, 0);
                            Gl.glCallList(hand);
                            Gl.glTranslated(0.6, 0, 0);
                            Gl.glCallList(hand);
                            // отключаем режим текстурирования 
                            Gl.glDisable(Gl.GL_TEXTURE_2D);
                            break;
                    }
                }
                else
                {
                    switch (texturArea)
                    {

                        case 1:
                            Gl.glEnable(Gl.GL_TEXTURE_2D);
                            Gl.glEnable(Gl.GL_TEXTURE_GEN_S);
                            Gl.glEnable(Gl.GL_TEXTURE_GEN_T);

                            switch_GL_TEXTURE_GEN_MODE();

                            Gl.glCallList(head);

                            Gl.glDisable(Gl.GL_TEXTURE_GEN_S);
                            Gl.glDisable(Gl.GL_TEXTURE_GEN_T);
                            Gl.glDisable(Gl.GL_TEXTURE_2D);

                            Gl.glCallList(head);
                            Gl.glCallList(body);
                            Gl.glCallList(foot);
                            Gl.glTranslated(0.4, 0.6, 0.65);
                            Gl.glRotatef(angle, 1, 0, 0);
                            Gl.glCallList(hand);
                            Gl.glTranslated(0.6, 0, 0);
                            Gl.glCallList(hand);

                            break;

                        case 2:

                            Gl.glCallList(head);

                            Gl.glEnable(Gl.GL_TEXTURE_2D);
                            Gl.glEnable(Gl.GL_TEXTURE_GEN_S);
                            Gl.glEnable(Gl.GL_TEXTURE_GEN_T);

                            switch_GL_TEXTURE_GEN_MODE();

                            Gl.glCallList(body);

                            Gl.glDisable(Gl.GL_TEXTURE_GEN_S);
                            Gl.glDisable(Gl.GL_TEXTURE_GEN_T);
                            Gl.glDisable(Gl.GL_TEXTURE_2D);

                          
                            Gl.glCallList(foot);
                            Gl.glTranslated(0.4, 0.6, 0.65);
                            Gl.glRotatef(angle, 1, 0, 0);
                            Gl.glCallList(hand);
                            Gl.glTranslated(0.6, 0, 0);
                            Gl.glCallList(hand);

                            break;

                        case 3:

                            Gl.glCallList(head);
                            Gl.glCallList(body);

                            Gl.glEnable(Gl.GL_TEXTURE_2D);
                            Gl.glEnable(Gl.GL_TEXTURE_GEN_S);
                            Gl.glEnable(Gl.GL_TEXTURE_GEN_T);

                            switch_GL_TEXTURE_GEN_MODE();

                            Gl.glCallList(foot);

                            Gl.glDisable(Gl.GL_TEXTURE_GEN_S);
                            Gl.glDisable(Gl.GL_TEXTURE_GEN_T);
                            Gl.glDisable(Gl.GL_TEXTURE_2D);

                            Gl.glTranslated(0.4, 0.6, 0.65);
                            Gl.glRotatef(angle, 1, 0, 0);
                            Gl.glCallList(hand);
                            Gl.glTranslated(0.6, 0, 0);
                            Gl.glCallList(hand);
                            
                            break;
                        
                        case 4:
                            Gl.glCallList(head);
                            Gl.glCallList(body);
                            Gl.glCallList(foot);

                            Gl.glEnable(Gl.GL_TEXTURE_2D);
                            Gl.glEnable(Gl.GL_TEXTURE_GEN_S);
                            Gl.glEnable(Gl.GL_TEXTURE_GEN_T);

                            switch_GL_TEXTURE_GEN_MODE();

                            Gl.glTranslated(0.4, 0.6, 0.65);
                            Gl.glRotatef(angle, 1, 0, 0);
                            Gl.glCallList(hand);
                            Gl.glTranslated(0.6, 0, 0);
                            Gl.glCallList(hand);

                            Gl.glDisable(Gl.GL_TEXTURE_GEN_S);
                            Gl.glDisable(Gl.GL_TEXTURE_GEN_T);
                            Gl.glDisable(Gl.GL_TEXTURE_2D);
                            break;

                       default:
                            Gl.glEnable(Gl.GL_TEXTURE_2D);
                            Gl.glEnable(Gl.GL_TEXTURE_GEN_S);
                            Gl.glEnable(Gl.GL_TEXTURE_GEN_T);

                            switch_GL_TEXTURE_GEN_MODE();

                            Gl.glCallList(head);
                            Gl.glCallList(body);
                            Gl.glCallList(foot);
                            Gl.glTranslated(0.4, 0.6, 0.65);
                            Gl.glRotatef(angle, 1, 0, 0);
                            Gl.glCallList(hand);
                            Gl.glTranslated(0.6, 0, 0);
                            Gl.glCallList(hand);

                            Gl.glDisable(Gl.GL_TEXTURE_GEN_S);
                            Gl.glDisable(Gl.GL_TEXTURE_GEN_T);
                            Gl.glDisable(Gl.GL_TEXTURE_2D);
                            break;
                    }
                }
            }
            else
            {
                Gl.glCallList(head);
                Gl.glCallList(body);
                Gl.glCallList(foot);
                Gl.glTranslated(0.4, 0.6, 0.65);
                Gl.glRotatef(angle, 1, 0, 0);
                Gl.glCallList(hand);
                Gl.glTranslated(0.6, 0, 0);
                Gl.glCallList(hand);
            }
        
            Gl.glPopMatrix();

            oglWin.Invalidate(); 
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Redrawing(oglWin, this);         
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {        
            switch (e.KeyCode)
            {
                case Keys.Q:
                    if (space == 0)
                        tx -= 0.5f;
                    else
                        stx -= 1f;
                    break;
                case Keys.W:
                    if (space == 0)
                        tx += 0.5f;
                    else
                        stx += 1f;
                    break;
                case Keys.A:
                    if (space == 0)
                        ty -= 0.5f;
                    else
                        sty -= 1f;
                    break;
                case Keys.S:
                    if (space == 0)
                        ty += 0.5f;
                    else
                        sty += 1f;
                    break;
                case Keys.Z:
                    if (space == 0)
                        tz -= 0.5f;
                    else
                        stz -= 1f;
                    break;
                case Keys.X:
                    if (space == 0)
                        tz += 0.5f;
                    else
                        stz += 1f;
                    break;
                case Keys.E:
                    if (space == 0)
                        xangle -= 10;
                    else
                        sxangle -= 10;
                    break;
                case Keys.R:
                    if (space == 0)
                        xangle += 10;
                    else
                        sxangle += 10;
                    break;
                case Keys.D:
                    if (space == 0)
                        yangle -= 10;
                    else
                        syangle -= 10;
                    break;
                case Keys.F:
                    if (space == 0)
                        yangle += 10;
                    else
                        syangle += 10;
                    break;
                case Keys.C:
                    if (space == 0)
                        zangle -= 10;
                    else
                        szangle -= 10;
                    break;
                case Keys.V:
                    if (space == 0)
                        zangle += 10;
                    else
                        szangle += 10;
                    break;

                case Keys.Space:
                    if (space == 0)
                        space = 1;
                    else
                        space = 0;
                    break;
                case Keys.F4:
                    if (axis)
                        axis = false;
                    else
                        axis = true;
                    break;
            }
        }// передается управление клавишам

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (space == 1)
            {
                ss += (float)e.Delta/10000;
            }
            else
            {
                s += (float)e.Delta/10000;
            }
        }

        private  uint MakeGlTexture(int Format, IntPtr pixels, int w, int h)
        {
            // индетефекатор текстурного объекта 
            uint texObject;

            // генерируем текстурный объект 
            Gl.glGenTextures(1, out texObject);

            // устанавливаем режим упаковки пикселей 
            Gl.glPixelStorei(Gl.GL_UNPACK_ALIGNMENT, 1);

            // создаем привязку к только что созданной текстуре 
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texObject);

            // ----------------------------------устанавливаем режим фильтрации и повторения текстуры-----------------------------------------

            initTextParam();

            //-------------------------------------------------------------------------------------------------------------------------------

            // создаем RGB или RGBA текстуру 
            switch (Format)
            {
                case Gl.GL_RGB:
                    Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGB, w, h, 0, Gl.GL_RGB, Gl.GL_UNSIGNED_BYTE, pixels);
                    break;

                case Gl.GL_RGBA:
                    Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA, w, h, 0, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, pixels);
                    break;
            }

            // возвращаем индетефекатор текстурного объекта 

            return texObject;
        }


        private void загрузкаТекстурыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // открываем окно выбора файла 
            DialogResult res = openFileDialog1.ShowDialog(); // есл файл выбран - и возвращен результат OK 
            if (res == DialogResult.OK)
            {
                // создаем изображение с индификатором imageId 
                Il.ilGenImages(1, out imageId);
                // делаем изображение текущим 
                Il.ilBindImage(imageId);

                // адрес изображения полученный с помощью окна выбра файла 
                string url = openFileDialog1.FileName;

                // пробуем загрузить изображение 
                if (Il.ilLoadImage(url))
                {
                    // если загрузка прошла успешно 
                    // сохраняем размеры изображения 
                    int width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
                    int height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);

                    // определяем число бит на пиксель 
                    int bitspp = Il.ilGetInteger(Il.IL_IMAGE_BITS_PER_PIXEL);

                    switch (bitspp) // в зависимости оп полученного результата 
                    {

                        // создаем текстуру используя режим GL_RGB или GL_RGBA 
                        case 24:
                            mGlTextureObject = MakeGlTexture(Gl.GL_RGB, Il.ilGetData(), width, height);
                            break;
                        case 32:
                            mGlTextureObject = MakeGlTexture(Gl.GL_RGBA, Il.ilGetData(), width, height);
                            break;
                    }

                    // активируем флаг, сигнализирующий загрузку текстуры 
                    textureIsLoad = true;
                    // очищаем память 
                    Il.ilDeleteImages(1, ref imageId);
                }
            }
        }

        private void головаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            texturArea = 1;
        }

        private void телоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            texturArea = 2;
        }

        private void ногиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            texturArea = 3;
        }

        private void рукиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            texturArea = 4;
        }

        private void весьОбъектToolStripMenuItem_Click(object sender, EventArgs e)
        {
            texturArea = 5;
        }

        private void gLNEARESTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL_TEXTURE_MIN_FILTER = true;
            initTextParam();
        }

        private void gLLINEARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL_TEXTURE_MIN_FILTER = false;
            initTextParam();
        }

        private void gLNEARESTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GL_TEXTURE_MAG_FILTER = true;
            initTextParam();
        }

        private void gLLINEARToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GL_TEXTURE_MAG_FILTER = false;
            initTextParam();
        }

        private void gLREPEATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL_TEXTURE_WRAP_S = false;
            initTextParam();
        }

        private void gLCLAMPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL_TEXTURE_WRAP_S = true;
            initTextParam();
        }

        private void gLREPEATToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GL_TEXTURE_WRAP_T = false;
            initTextParam();
        }

        private void gLCLAMPToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GL_TEXTURE_WRAP_T = true;
            initTextParam();
        }

        private void gLMODULATEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL_TEXTURE_ENV_MODE = true;
            initTextParam();
        }

        private void gLREPLACEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL_TEXTURE_ENV_MODE = false;
            initTextParam();
        }

        private void glTexGenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            texCoordMethod = false;
        }

        private void texCoordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            texCoordMethod = true;
        }

        private void gLOBJECTLINEARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL_TEXTURE_GEN_MODE = 0;
        }

        private void gLEYELINEARToolStripMenuItem_Click(object sender, EventArgs e)
        {
        GL_TEXTURE_GEN_MODE = 1;
        }

        private void gLSPHEREMAPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL_TEXTURE_GEN_MODE = 2;
        }

        private void вклВыклToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (light_on)
            {
                light_on = false;
                Gl.glDisable(Gl.GL_LIGHT1);
                Gl.glDisable(Gl.GL_LIGHT2);
            }
            else
            {
                light_on = true;
            }
        }
    }
}
