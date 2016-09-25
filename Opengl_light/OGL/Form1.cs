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
        public int head = 1, hand = 2, foot = 3, body = 4, bot = 5, pot = 1;

       
        public float global_x = 0.0f, global_y = 1.0f, global_z = 0.0f;
        public float[] colour_point = new float[4] { 0, 0, 0, 0 }; //Красный цвет
        // для источников--------------------------------------------

/*----------------------------------------------------------------------------------*/
        /*
          // направленный источник света

                //GLfloat light0_diffuse[] = { 0.4, 0.7, 0.2 };
                float[] light0_diffuse = new float[3] { 1.0f, 1.0f, 1.0f };
                //GLfloat light0_direction[] = { 0.0, 0.0, 1.0, 0.0 };
                float[] light0_direction = new float[4] { 3.5f, 3.5f, 0.0f, 0.0f };
         */
        public float[] pointLight1_position = new float[4] { 0.0f, 0.0f, 0.0f, 0.0f }; // позиция
        public float[] pointLight1_ambient = new float[3] { 1, 0, 0 }; // цвет фонового излучения
        public float[] pointLight1_diffuse = new float[3] { 1, 0, 0 };  // цвет рассеянного излучения
        public float[] pointLight1_specular = new float[4] { 1, 0, 0, 1 }; // цвет зеркального излучения
        public float[] pointLight1_const = new float[3] { 1, 1, 1 }; // коэффициенты затухания
        public float[] pointLight1_direct = new float[4] { 3.5f, 3.5f, 0.0f, 0.0f };

/*----------------------------------------------------------------------------------*/

        // точечный источник света
        // убывание интенсивности с расстоянием
        // отключено (по умолчанию)

        float[] light1_diffuse = new float[3] { 0.4f, 0.7f, 0.2f };
        float[] light1_position = new float[4] { 0.0f, 1.0f, 0.0f, 1.0f };

        public float[] pointLight2_position = new float[4] { 0.0f, 0.0f, 0.0f, 1.0f }; // позиция
        //public float[] pointLight2_ambient = new float[3] { 0, 1, 1 }; // цвет фонового излучения
       // public float[] pointLight2_diffuse = new float[3] { 0, 1, 1 };  // цвет рассеянного излучения
         public float[] pointLight2_diffuse = new float[3] { 1.0f, 0.0f, 0.0f};  // цвет рассеянного излучения
        //public float[] pointLight2_specular = new float[4] { 1, 0, 0, 1 }; // цвет зеркального излучения
        //public float[] pointLight2_const = new float[3] { 1, 1, 1 }; // коэффициенты затухания

/*----------------------------------------------------------------------------------*/
        // точечный источник света
                // убывание интенсивности с расстоянием
                // задано функцией f(d) = 1.0 / (0.4 * d * d + 0.2 * d)

               
               
              /*  Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_DIFFUSE, light2_diffuse);
                Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_POSITION, light2_position);
                Gl.glLightf(Gl.GL_LIGHT2, Gl.GL_CONSTANT_ATTENUATION, 0.0f);
                Gl.glLightf(Gl.GL_LIGHT2, Gl.GL_LINEAR_ATTENUATION, 0.2f);
                Gl.glLightf(Gl.GL_LIGHT2, Gl.GL_QUADRATIC_ATTENUATION, 0.4f);*/
        public float[] pointLight3_diffuse = new float[3] { 1.0f, 0.0f, 0.0f };
        public float[] pointLight3_position = new float[4] { 0.0f, 0.0f, 0.0f, 1.0f };
        public float pointLight3_const_att = 0.0f;
        public float pointLight3_linear_att = 0.2f;
        public float pointLight3_quad_att = 0.4f;


/*----------------------------------------------------------------------------------*/
        	// прожектор
		// убывание интенсивности с расстоянием
		// отключено (по умолчанию)
		// половина угла при вершине 90 градусов
		// направление на центр плоскости
		
		public float[] pointLight4_diffuse = new float[3] { 1.0f, 0.0f, 0.0f };
		//GLfloat light3_position[] = { 0.0, 0.0, 1.0, 1.0 };
		public float[] pointLight4_position = new float[4] { 0f, 0f, 0.0f, 1.0f };
		//GLfloat light3_spot_direction[] = { 0.0, 0.0, 1.0 };
		public float[] pointLight4_spot_direction = new float[3] { 0.0f, 2.5f, 0.0f };
		


/*----------------------------------------------------------------------------------*/



        // прожектор
		// убывание интенсивности с расстоянием
		// отключено (по умолчанию)
		// половина угла при вершине 90 градусов
		// направление на центр плоскости
		// включен расчет убывания интенсивности для прожектора
		
		/*GLfloat light4_diffuse[] = { 0.4, 0.7, 0.2 };
		//GLfloat light4_position[] = { 0.0, 0.0, 1.0, 1.0 };
		//GLfloat light4_spot_direction[] = { 0.0, 0.0, 1.0 };
		GLfloat light4_position[] = { 0.0, 0.0, 1.5, 1.0 };
		GLfloat light4_spot_direction[] = { 3.0, 3.0, 0.5 };*/
        public float[] pointLight5_diffuse = new float[3] { 1.0f, 0.0f, 0.0f };
		//GLfloat light3_position[] = { 0.0, 0.0, 1.0, 1.0 };
		public float[] pointLight5_position = new float[4] { 0f, 0f, 0.0f, 1.0f };
		//GLfloat light3_spot_direction[] = { 0.0, 0.0, 1.0 };
		public float[] pointLight5_spot_direction = new float[3] { 0.0f, 20f, 0.0f };
		

/*----------------------------------------------------------------------------------*/



         // несколько источников света

        float[] pointLight0_diffuse = { 1.0f, 0.0f, 0.0f };
        float[] pointLight0_position = { 0.5f * (float)Math.Cos(0.0), 0.5f * (float)Math.Sin(0.0), 1.0f, 1.0f };
        float[] pointLight6_diffuse = { 0.0f, 1.0f, 0.0f };
        float[] pointLight6_position = { 0.5f * (float)Math.Cos(2 * Math.PI / 3), 0.5f * (float)Math.Sin(2 * Math.PI / 3), 1.0f, 1.0f };
        float[] pointLight7_diffuse = { 0.0f, 0.0f, 1.0f };
        float[] pointLight7_position = { 0.5f * (float)Math.Cos(4 * Math.PI / 3), 0.5f * (float)Math.Sin(4 * Math.PI / 3), 1.0f, 1.0f };

        //-----------------------------------------------------------

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



            if (checkBox1.Checked == true) {

               /* Gl.glDisable(Gl.GL_LIGHT2);
                Gl.glDisable(Gl.GL_LIGHT3);
                Gl.glDisable(Gl.GL_LIGHT4);
                Gl.glDisable(Gl.GL_LIGHT5);
                Gl.glDisable(Gl.GL_LIGHT6);
                Gl.glDisable(Gl.GL_LIGHT7);
                Gl.glDisable(Gl.GL_LIGHT0);*/
                Gl.glEnable(Gl.GL_LIGHT1);
                Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_DIFFUSE, pointLight1_diffuse);
               // Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_POSITION, pointLight1_position);
                //Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_AMBIENT, pointLight1_ambient);
                //Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_SPECULAR, pointLight1_specular);
                Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_POSITION, pointLight1_direct);


                Gl.glPushMatrix();
                Gl.glTranslated(pointLight1_direct[0], pointLight1_direct[1], pointLight1_direct[2]);
            
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, colour_point); //Цвет точки
                Glut.glutSolidSphere(0.1d,32,32);
                Gl.glPopMatrix();
                Gl.glFlush();

                

            }

            if (checkBox2.Checked == true)
            {
                /*Gl.glDisable(Gl.GL_LIGHT1);
                Gl.glDisable(Gl.GL_LIGHT3);
                Gl.glDisable(Gl.GL_LIGHT4);
                Gl.glDisable(Gl.GL_LIGHT5);
                Gl.glDisable(Gl.GL_LIGHT6);
                Gl.glDisable(Gl.GL_LIGHT7);
                Gl.glDisable(Gl.GL_LIGHT0);*/
                Gl.glEnable(Gl.GL_LIGHT2);
                Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_DIFFUSE, pointLight2_diffuse);
                Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_POSITION, pointLight2_position);



                Gl.glPushMatrix();
                Gl.glTranslated(pointLight2_position[0], pointLight2_position[1], pointLight2_position[2]);
               
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, colour_point); //Цвет точки
                Glut.glutSolidSphere(0.2d, 32, 32);
                Gl.glPopMatrix();
                Gl.glFlush();
               // Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_AMBIENT, pointLight2_ambient);
               // Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_SPECULAR, pointLight2_specular);
                

            }

            if (checkBox3.Checked == true)
            {
                /*Gl.glDisable(Gl.GL_LIGHT1);
                Gl.glDisable(Gl.GL_LIGHT2);
                Gl.glDisable(Gl.GL_LIGHT4);
                Gl.glDisable(Gl.GL_LIGHT5);
                Gl.glDisable(Gl.GL_LIGHT6);
                Gl.glDisable(Gl.GL_LIGHT7);
                Gl.glDisable(Gl.GL_LIGHT0);*/
                Gl.glEnable(Gl.GL_LIGHT3);
                Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_DIFFUSE, pointLight3_diffuse);
                Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_POSITION, pointLight3_position);
                Gl.glLightf(Gl.GL_LIGHT3, Gl.GL_CONSTANT_ATTENUATION, pointLight3_const_att);
                Gl.glLightf(Gl.GL_LIGHT3, Gl.GL_LINEAR_ATTENUATION, pointLight3_linear_att);
                Gl.glLightf(Gl.GL_LIGHT3, Gl.GL_QUADRATIC_ATTENUATION, pointLight3_quad_att);
                Gl.glPushMatrix();
                Gl.glTranslated(pointLight3_position[0], pointLight3_position[1], pointLight3_position[2]);
                // Gl.glRotated(45, 1, 1, 0);
                // рисуем чайник с помощью библиотеки FreeGLUT 
                //Glut.glutSolidTeapot(1);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, colour_point); //Цвет точки
                Glut.glutSolidSphere(0.2d, 32, 32);
                Gl.glPopMatrix();
                Gl.glFlush();

            }






            if (checkBox4.Checked == true)
            {

                /*Gl.glDisable(Gl.GL_LIGHT1);
                Gl.glDisable(Gl.GL_LIGHT2);
                Gl.glDisable(Gl.GL_LIGHT3);
                Gl.glDisable(Gl.GL_LIGHT5);
                Gl.glDisable(Gl.GL_LIGHT6);
                Gl.glDisable(Gl.GL_LIGHT7);
                Gl.glDisable(Gl.GL_LIGHT0);*/


                Gl.glEnable(Gl.GL_LIGHT4);
                Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_DIFFUSE, pointLight4_diffuse);
                Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_POSITION, pointLight4_position);
                Gl.glLightf(Gl.GL_LIGHT4, Gl.GL_SPOT_CUTOFF, 90);
                Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_SPOT_DIRECTION, pointLight4_spot_direction);

                Gl.glPushMatrix();
                Gl.glTranslated(pointLight4_position[0], pointLight4_position[1], pointLight4_position[2]);
                // Gl.glRotated(45, 1, 1, 0);
                // рисуем чайник с помощью библиотеки FreeGLUT 
                //Glut.glutSolidTeapot(1);
                Glut.glutSolidSphere(0.2d, 32, 32);
                Gl.glPopMatrix();
                Gl.glFlush();

            }


            if (checkBox5.Checked == true)
            {

               /* Gl.glDisable(Gl.GL_LIGHT1);
                Gl.glDisable(Gl.GL_LIGHT2);
                Gl.glDisable(Gl.GL_LIGHT3);
                Gl.glDisable(Gl.GL_LIGHT4);
                Gl.glDisable(Gl.GL_LIGHT6);
                Gl.glDisable(Gl.GL_LIGHT7);
                Gl.glDisable(Gl.GL_LIGHT0);*/


                Gl.glEnable(Gl.GL_LIGHT5);
                Gl.glLightfv(Gl.GL_LIGHT5, Gl.GL_DIFFUSE, pointLight5_diffuse);
                Gl.glLightfv(Gl.GL_LIGHT5, Gl.GL_POSITION, pointLight5_position);
                Gl.glLightf(Gl.GL_LIGHT5, Gl.GL_SPOT_CUTOFF, 90);
                Gl.glLightfv(Gl.GL_LIGHT5, Gl.GL_SPOT_DIRECTION, pointLight5_spot_direction);
                Gl.glLightf(Gl.GL_LIGHT5, Gl.GL_SPOT_EXPONENT, 1.5f);

                Gl.glPushMatrix();
                Gl.glTranslated(pointLight5_position[0], pointLight5_position[1], pointLight5_position[2]);

                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, colour_point); //Цвет точки
                Glut.glutSolidSphere(0.2d, 32, 32);
                Gl.glPopMatrix();
                Gl.glFlush();

            }


            if (checkBox6.Checked == true)
            {
                /*Gl.glDisable(Gl.GL_LIGHT1);
                Gl.glDisable(Gl.GL_LIGHT2);
                Gl.glDisable(Gl.GL_LIGHT3);
                Gl.glDisable(Gl.GL_LIGHT4);
                Gl.glDisable(Gl.GL_LIGHT5);*/
                
                
                Gl.glEnable(Gl.GL_LIGHT0);
                Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, pointLight0_diffuse);
                Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, pointLight0_position);
                Gl.glLightf(Gl.GL_LIGHT0, Gl.GL_CONSTANT_ATTENUATION, 0.0f);
                Gl.glLightf(Gl.GL_LIGHT0, Gl.GL_LINEAR_ATTENUATION, 0.4f);
                Gl.glLightf(Gl.GL_LIGHT0, Gl.GL_QUADRATIC_ATTENUATION, 0.8f);

                Gl.glEnable(Gl.GL_LIGHT6);
                Gl.glLightfv(Gl.GL_LIGHT6, Gl.GL_DIFFUSE, pointLight6_diffuse);
                Gl.glLightfv(Gl.GL_LIGHT6, Gl.GL_POSITION, pointLight6_position);
                Gl.glLightf(Gl.GL_LIGHT6, Gl.GL_CONSTANT_ATTENUATION, 0.0f);
                Gl.glLightf(Gl.GL_LIGHT6, Gl.GL_LINEAR_ATTENUATION, 0.4f);
                Gl.glLightf(Gl.GL_LIGHT6, Gl.GL_QUADRATIC_ATTENUATION, 0.8f);

                Gl.glEnable(Gl.GL_LIGHT7);
                Gl.glLightfv(Gl.GL_LIGHT7, Gl.GL_DIFFUSE, pointLight7_diffuse);
                Gl.glLightfv(Gl.GL_LIGHT7, Gl.GL_POSITION, pointLight7_position);
                Gl.glLightf(Gl.GL_LIGHT7, Gl.GL_CONSTANT_ATTENUATION, 0.0f);
                Gl.glLightf(Gl.GL_LIGHT7, Gl.GL_LINEAR_ATTENUATION, 0.4f);
                Gl.glLightf(Gl.GL_LIGHT7, Gl.GL_QUADRATIC_ATTENUATION, 0.8f);
            }


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


            /*установка начальных значений текстбоксов*/

           
            
               
                textBox19.Text = Convert.ToString(pointLight1_direct[0]);
                textBox25.Text = Convert.ToString(pointLight1_direct[1]);
                textBox13.Text = Convert.ToString(pointLight1_direct[2]);
                textBox1.Text = Convert.ToString(pointLight1_diffuse[0]);
                textBox31.Text = Convert.ToString(pointLight1_diffuse[1]);
                textBox12.Text = Convert.ToString(pointLight1_diffuse[2]);
              

               
                textBox14.Text = Convert.ToString(pointLight2_position[0]);
                textBox2.Text = Convert.ToString(pointLight2_position[1]);
                textBox11.Text = Convert.ToString(pointLight2_position[2]);
                textBox26.Text = Convert.ToString(pointLight2_diffuse[0]);
                textBox32.Text = Convert.ToString(pointLight2_diffuse[1]);
                textBox20.Text = Convert.ToString(pointLight2_diffuse[2]);
           

            
                textBox21.Text = Convert.ToString(pointLight3_position[0]);
                textBox27.Text = Convert.ToString(pointLight3_position[1]);
                textBox15.Text = Convert.ToString(pointLight3_position[2]);
                textBox3.Text = Convert.ToString(pointLight3_diffuse[0]);
                textBox33.Text = Convert.ToString(pointLight3_diffuse[1]);
                textBox10.Text = Convert.ToString(pointLight3_diffuse[2]);
          
            
                textBox22.Text = Convert.ToString(pointLight4_position[0]);
                textBox34.Text = Convert.ToString(pointLight4_position[1]);
                textBox4.Text = Convert.ToString(pointLight4_position[2]);
                textBox23.Text = Convert.ToString(pointLight4_diffuse[0]);
                textBox16.Text = Convert.ToString(pointLight4_diffuse[1]);
                textBox17.Text = Convert.ToString(pointLight4_diffuse[2]);
            
         
                textBox28.Text = Convert.ToString(pointLight5_position[0]);
                textBox29.Text = Convert.ToString(pointLight5_position[1]);
                textBox8.Text = Convert.ToString(pointLight5_position[2]);
                textBox5.Text = Convert.ToString(pointLight5_diffuse[0]);
                textBox35.Text = Convert.ToString(pointLight5_diffuse[1]);
                textBox7.Text = Convert.ToString(pointLight5_diffuse[2]);
            


           

            //----------------------------------------------------------------------------------------------------
            

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glLoadIdentity();
            Gl.glClearColor(0, 0, 0, 1);
            Gl.glNewList(head, Gl.GL_COMPILE);
            float[] color = new float[4] { 1.0f, 0.0f, 0.0f, 1.0f }; //Красный цвет
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, color); //Цвет чайника
            Gl.glPushMatrix();
            Gl.glTranslated(0, 1, 0);
           // Gl.glRotated(45, 1, 1, 0);
            // рисуем чайник с помощью библиотеки FreeGLUT 
            Glut.glutSolidTeapot(1);
            //Glut.glutWireSphere(2.0d,32,32);
            Gl.glPopMatrix();
            Gl.glFlush();
            
            Gl.glEndList();
           


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

            angle += 5;

            Gl.glCallList(head);


            
        
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

                case Keys.Shift:
                    if (space == 0)
                        space = 1;
                    else
                        space = 0;
                    break;
                case Keys.F1:
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

      
        
        private void вклВыклToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (light_on)
            {
                light_on = false;
                Gl.glDisable(Gl.GL_LIGHT0);
                Gl.glDisable(Gl.GL_LIGHT1);
                Gl.glDisable(Gl.GL_LIGHT2);
                Gl.glDisable(Gl.GL_LIGHT3);
                Gl.glDisable(Gl.GL_LIGHT4);
                Gl.glDisable(Gl.GL_LIGHT5);
                Gl.glDisable(Gl.GL_LIGHT6);
                Gl.glDisable(Gl.GL_LIGHT7);

            }
            else
            {
                light_on = true;
            }
        }

       

        private void инфоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Цыпунов Максим ВТ-Б11 2014 год");
        }

     

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                pointLight1_direct[0] = (float)Convert.ToDouble(textBox19.Text);
                pointLight1_direct[1] = (float)Convert.ToDouble(textBox25.Text);
                pointLight1_direct[2] = (float)Convert.ToDouble(textBox13.Text);
                pointLight1_diffuse[0] = (float)Convert.ToDouble(textBox1.Text);
                pointLight1_diffuse[1] = (float)Convert.ToDouble(textBox31.Text);
                pointLight1_diffuse[2] = (float)Convert.ToDouble(textBox12.Text);
              
                
            }
            if (checkBox2.Checked == true)
            {
                pointLight2_position[0] = (float)Convert.ToDouble(textBox14.Text);
                pointLight2_position[1] = (float)Convert.ToDouble(textBox2.Text);
                pointLight2_position[2] = (float)Convert.ToDouble(textBox11.Text);
                pointLight2_diffuse[0] = (float)Convert.ToDouble(textBox26.Text);
                pointLight2_diffuse[1] = (float)Convert.ToDouble(textBox32.Text);
                pointLight2_diffuse[2] = (float)Convert.ToDouble(textBox20.Text);
            }
            if (checkBox3.Checked == true)
            {
                pointLight3_position[0] = (float)Convert.ToDouble(textBox21.Text);
                pointLight3_position[1] = (float)Convert.ToDouble(textBox27.Text);
                pointLight3_position[2] = (float)Convert.ToDouble(textBox15.Text);
                pointLight3_diffuse[0] = (float)Convert.ToDouble(textBox3.Text);
                pointLight3_diffuse[1] = (float)Convert.ToDouble(textBox33.Text);
                pointLight3_diffuse[2] = (float)Convert.ToDouble(textBox10.Text);
            }
            if (checkBox4.Checked == true)
            {
                pointLight4_position[0] = (float)Convert.ToDouble(textBox22.Text);
                pointLight4_position[1] = (float)Convert.ToDouble(textBox34.Text);
                pointLight4_position[2] = (float)Convert.ToDouble(textBox4.Text);
                pointLight4_diffuse[0] = (float)Convert.ToDouble(textBox23.Text);
                pointLight4_diffuse[1] = (float)Convert.ToDouble(textBox16.Text);
                pointLight4_diffuse[2] = (float)Convert.ToDouble(textBox17.Text);
            }
            if (checkBox5.Checked == true)
            {
                pointLight5_position[0] = (float)Convert.ToDouble(textBox28.Text);
                pointLight5_position[1] = (float)Convert.ToDouble(textBox29.Text);
                pointLight5_position[2] = (float)Convert.ToDouble(textBox8.Text);
                pointLight5_diffuse[0] = (float)Convert.ToDouble(textBox5.Text);
                pointLight5_diffuse[1] = (float)Convert.ToDouble(textBox35.Text);
                pointLight5_diffuse[2] = (float)Convert.ToDouble(textBox7.Text);
            }

            enable_light();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) { Gl.glEnable(Gl.GL_LIGHT1); }
            else { Gl.glDisable(Gl.GL_LIGHT1); } 
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked) { Gl.glEnable(Gl.GL_LIGHT2); }
            else { Gl.glDisable(Gl.GL_LIGHT2); } 
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked) { Gl.glEnable(Gl.GL_LIGHT3); }
            else { Gl.glDisable(Gl.GL_LIGHT3); } 
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked) { Gl.glEnable(Gl.GL_LIGHT4); }
            else { Gl.glDisable(Gl.GL_LIGHT4); } 
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked) { Gl.glEnable(Gl.GL_LIGHT5); }
            else { Gl.glDisable(Gl.GL_LIGHT5); } 
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked) { Gl.glEnable(Gl.GL_LIGHT0);
                                     Gl.glEnable(Gl.GL_LIGHT6);
                                     Gl.glEnable(Gl.GL_LIGHT7);
            }
            else { Gl.glDisable(Gl.GL_LIGHT0);
                   Gl.glDisable(Gl.GL_LIGHT6);
                   Gl.glDisable(Gl.GL_LIGHT7);
            }
            
        }

       

       
    }
}
