using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Lab4
{
    public partial class Form : System.Windows.Forms.Form
    {
        public static DirectBitmap dbm;

        public static bool fill = true;
        public static bool backfaceCulling = true;
        public static bool zBuffer = true;
        public static bool edges = true;

        public static List<Light> lights = new List<Light>();

        private List<Model> models = new List<Model>();
        private List<Scene> scenes = new List<Scene>();
        private List<Camera> cameras = new List<Camera>();

        public static Camera currentCam;
        private Scene currentScene;
        private Model currentModel;

        private Renderer renderer;

        private double prevX = -1;
        private double prevY = -1;

        private int counter = 0;

        private int FPS = 0;
        private DateTime date;

        public Form()
        {
            InitializeComponent();
            this.Text = "FPS: " + FPS;
            dbm = new DirectBitmap(drawingPictureBox.Width, drawingPictureBox.Height);
            drawingPictureBox.Image = dbm.Bitmap;

            currentCam = new Camera(new Vector(0, 0, 10), new Vector(0, 0, 0), 1, 100, 1);
            currentScene = new Scene(models, currentCam, lights);
            scenes.Add(currentScene);
            cameras.Add(currentCam);

            camerasListBox.Items.Add("Camera 0");

            renderer = new Renderer();

            fpsTimer.Start();
            date = DateTime.Now;

            lightX.Maximum = dbm.Width - 1;
            lightY.Maximum = dbm.Height - 1;
        }

        private void drawAll()
        {
            FPS++;
            dbm.Dispose();
            dbm = new DirectBitmap(drawingPictureBox.Width, drawingPictureBox.Height);
          
           
            renderer.render(currentScene);
            foreach (Light light in lights)
                light.Draw();
            drawingPictureBox.Image = dbm.Bitmap;
            drawingPictureBox.Invalidate();
        }

        private void setModelVectors(Model model)
        {
            model.position.values[0] = (double)positionX.Value;
            model.position.values[1] = -(double)positionY.Value;
            model.position.values[2] = (double)positionZ.Value;

            model.rotation.values[0] = (double)rotationX.Value;
            model.rotation.values[1] = (double)rotationY.Value;
            model.rotation.values[2] = (double)rotationZ.Value;

            model.scale.values[0] = (double)scaleX.Value;
            model.scale.values[1] = (double)scaleY.Value;
            model.scale.values[2] = (double)scaleZ.Value;
        }

        private void cuboidButton_Click(object sender, EventArgs e)
        {
            double x = (double)cuboidX.Value;
            double y = (double)cuboidY.Value;
            double z = (double)cuboidZ.Value;

            Cuboid model = new Cuboid(x, y , z);

            setModelVectors(model);

            models.Add(model);


            addModelToList(model);

        }

        private void coneButton_Click(object sender, EventArgs e)
        {
            int div = (int)coneDivision.Value;
            double radius = (double)coneRadius.Value;
            double height = (double)coneHeight.Value;

            Cone model = new Cone(div, radius, height);

            setModelVectors(model);

            models.Add(model);

            addModelToList(model);

        }

        private void sphereButton_Click(object sender, EventArgs e)
        {
            double radius = (double)sphereRadius.Value;
            int theta = (int)sphereTheta.Value;
            int phi = (int)spherePhi.Value;

            Sphere model = new Sphere(radius, phi, theta);

            setModelVectors(model);

            models.Add(model);

            addModelToList(model);

        }

        private void cylinderButton_Click(object sender, EventArgs e)
        {
            int div = (int)cylinderDivision.Value;
            double height = (double)cylinderHeight.Value;
            double radius = (double)cylinderRadius.Value;

            Cylinder model = new Cylinder(div, radius, height);

            setModelVectors(model);

            models.Add(model);

            addModelToList(model);

        }

        private void addCameraToList(Camera cam)
        {
            camerasListBox.Items.Add("Camera " + camerasListBox.Items.Count);
        }

        private void addModelToList(Model model)
        {
            modelsListBox.Items.Add(model.name + " " + +modelsListBox.Items.Count);
        }

        private void addLightToList(Light light)
        {
            lightsListBox.Items.Add("Light " + lightsListBox.Items.Count);
        }


        private void position_ValueChanged(object sender, EventArgs e)
        {
            if (currentModel == null) return;
            Vector position = new Vector((double)positionX.Value, -(double)positionY.Value, (double)positionZ.Value);
            currentModel.position = position;
        }

        private void rotation_ValueChanged(object sender, EventArgs e)
        {
            if (currentModel == null) return;
            Vector rotation = new Vector(convertToRadians((double)rotationX.Value), convertToRadians((double)rotationY.Value), convertToRadians((double)rotationZ.Value));
            currentModel.rotation = rotation;
        }

        private void scale_ValueChanged(object sender, EventArgs e)
        {
            if (currentModel == null) return;
            Vector scale = new Vector((double)scaleX.Value, (double)scaleY.Value, (double)scaleZ.Value);
            currentModel.scale = scale;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            dbm = new DirectBitmap(drawingPictureBox.Width, drawingPictureBox.Height);
            drawingPictureBox.Image = dbm.Bitmap;
            models = new List<Model>();
            currentModel = null;
            for (int i = 0; i < scenes.Count; i++)
                scenes[i].models = models;
            modelsListBox.Items.Clear();
        }

        private void modelsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = modelsListBox.SelectedIndex;
            if (index == -1) return;
            currentModel = models[index];

            Vector position = currentModel.position;
            Vector rotation = currentModel.rotation;
            Vector scale = currentModel.scale;

            positionX.Value = (decimal)position.values[0];
            positionY.Value = -(decimal)position.values[1];
            positionZ.Value = (decimal)position.values[2];

            rotationX.Value = (decimal)rotation.values[0];
            rotationY.Value = (decimal)rotation.values[1];
            rotationZ.Value = (decimal)rotation.values[2];

            scaleX.Value = (decimal)scale.values[0];
            scaleY.Value = (decimal)scale.values[1];
            scaleZ.Value = (decimal)scale.values[2];
        }

        private void modelDeleteButton_Click(object sender, EventArgs e)
        {
            int index = modelsListBox.SelectedIndex;
            if (index == -1) return;
            modelsListBox.Items.RemoveAt(index);
            models.RemoveAt(index);
        }

        private void fillCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            fill = !fill;
        }

        private void zBufferingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            zBuffer = !zBuffer;
        }

        private void cullingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            backfaceCulling = !backfaceCulling;
        }

        private void camerasListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = camerasListBox.SelectedIndex;

            if (index == -1) return;

            currentCam = cameras[index];

            currentScene = scenes.Find(s => s.camera == currentCam);

        }

        private void cameraDeleteButton_Click(object sender, EventArgs e)
        {
            int index = camerasListBox.SelectedIndex;
            if (index == -1 || cameras.Count == 1) return;
            camerasListBox.Items.RemoveAt(index);
            cameras.RemoveAt(index);

            currentCam = cameras[0];

            currentScene = scenes.Find(s => s.camera == currentCam);

            camerasListBox.SelectedIndex = 0;

        }

        private void cameraButton_Click(object sender, EventArgs e)
        {
            double fov = convertToRadians((double)cameraFOV.Value);
            double far = (double)cameraFar.Value;
            double close = (double)cameraClose.Value;

            if (far <= close)
            {
                MessageBox.Show("Close cannot be greater than far", "Wrong data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Camera newCam;
            if (currentModel == null)
            {
                newCam = new Camera(new Vector(0, 0, 10), new Vector(0, 0, 0), fov, far, close);
                
            }
            else
            {
                newCam = new Camera(new Vector(0, 0, 10), currentModel.position, fov, far, close);
            }
            cameras.Add(newCam);
            addCameraToList(newCam);
            currentScene = new Scene(models, newCam, lights);
            scenes.Add(currentScene);
            currentCam = newCam;
        }

        private void moveCameraX(Camera cam, double x)
        {
            cameras.Find(c => c==cam).position.values[0] += x;
        }

        private void moveCameraY(Camera cam, double y)
        {
            cameras.Find(c => c == cam).position.values[1] += y;
        }

        private void moveCameraZ(Camera cam, double z)
        {
            cameras.Find(c => c == cam).position.values[2] += z;
        }

        private void drawingPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            prevX = e.X;
            prevY = e.Y;
        }

        private void drawingPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (prevY == -1) return;
            counter++;
            if (counter != 5) return;
            counter = 0;
            double dx = e.X - prevX;
            double dy = e.Y - prevY;
            if(e.Button == MouseButtons.Left)
            {
                if (dx != 0) moveCameraX(currentCam, -dx / drawingPictureBox.Width);
                if (dy != 0) moveCameraY(currentCam, -dy / drawingPictureBox.Height);
            }
            else if(e.Button == MouseButtons.Right)
            {
                if (dy != 0) moveCameraZ(currentCam, dy / drawingPictureBox.Height);
            }
            
        }

        private void drawingPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            prevY = -1;
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                moveCameraZ(currentCam, -0.3);
            }
            else if (e.KeyCode == Keys.S)
            {
                moveCameraZ(currentCam, 0.3);
            }
            else if (e.KeyCode == Keys.D)
            {
                moveCameraX(currentCam, 0.3);
            }
            else if (e.KeyCode == Keys.A)
            {
                moveCameraX(currentCam, -0.3);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "TXT Files (*.txt)|*.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate);
                BinaryFormatter binaryFormatter = new BinaryFormatter();

                binaryFormatter.Serialize(fs, scenes);
                fs.Close();
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"\Debug";
            openFileDialog.Filter = "TXT Files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.CheckFileExists == false) return;
                FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                scenes = new List<Scene>();

                scenes = (List<Scene>)binaryFormatter.Deserialize(fileStream);

                models = scenes.First().models;

                lights = scenes.First().lights;

                cameras = new List<Camera>();

                foreach(Scene s in scenes)
                {
                    cameras.Add(s.camera);
                }

                camerasListBox.Items.Clear();

                lightsListBox.Items.Clear();

                modelsListBox.Items.Clear();

                currentScene = scenes.First();
                currentModel = null;
                currentCam = currentScene.camera;

                foreach (Model m in models)
                    addModelToList(m);

                foreach (Camera c in cameras)
                    addCameraToList(c);

                foreach (Light l in lights)
                    addLightToList(l) ;


            }
        }

        private double convertToRadians(double angle)
        {
            return angle * Math.PI / 180;
        }

        private void cameraEditButton_Click(object sender, EventArgs e)
        {
            int index = camerasListBox.SelectedIndex;
            if (index == -1) return;

            Camera cam = cameras[index];

            double fov = convertToRadians((double)cameraFOV.Value);
            double far = (double)cameraFar.Value;
            double close = (double)cameraClose.Value;

            cam.fov = fov;
            cam.far = far;
            cam.close = close;

            currentCam = cam;
            currentScene = scenes.Find(s => s.camera == currentCam);

        }

        private void modelEditButton_Click(object sender, EventArgs e)
        {
            int index = modelsListBox.SelectedIndex;

            if (index == -1) return;

            Model model = models[index];

            foreach (Scene s in scenes)
                s.models.Remove(model);

            switch(model.name)
            {
                case "Cuboid":
                    {
                        double x = (double)cuboidX.Value;
                        double y = (double)cuboidY.Value;
                        double z = (double)cuboidZ.Value;

                        Cuboid newModel = new Cuboid(x, y, z);

                        setModelVectors(newModel);

                        foreach (Scene s in scenes)
                            s.models.Insert(index, newModel);


                        break;
                    }
                case "Cone":
                    {
                        int div = (int)coneDivision.Value;
                        double radius = (double)coneRadius.Value;
                        double height = (double)coneHeight.Value;

                        Cone newModel = new Cone(div, radius, height);

                        setModelVectors(newModel);

                        foreach (Scene s in scenes)
                            s.models.Insert(index, newModel);


                        break;
                    }
                case "Cylinder":
                    {
                        int div = (int)cylinderDivision.Value;
                        double height = (double)cylinderHeight.Value;
                        double radius = (double)cylinderRadius.Value;

                        Cylinder newModel = new Cylinder(div, radius, height);

                        setModelVectors(newModel);

                        foreach (Scene s in scenes)
                            s.models.Insert(index, newModel);

                        break;
                    }
                case "Sphere":
                    {
                        double radius = (double)sphereRadius.Value;
                        int theta = (int)sphereTheta.Value;
                        int phi = (int)spherePhi.Value;

                        Sphere newModel = new Sphere(radius, phi, theta);

                        setModelVectors(newModel);

                        foreach (Scene s in scenes)
                            s.models.Insert(index, newModel);


                        break;
                    }
                default:
                    {
                        break;
                    }
                    
                    
            }
        }

        private void fpsTimer_Tick(object sender, EventArgs e)
        {
            if ((DateTime.Now - date).TotalSeconds >= 1)
            {
                this.Text = "FPS: " + FPS;
                date = DateTime.Now;
                FPS = 0;
            }
            drawAll();
        }

        private void edgesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            edges = !edges;
        }

        private void lightButton_Click(object sender, EventArgs e)
        {           
            double inten = (double)intensity.Value;
            double att = (double)attentuation.Value;
            Color color = colorButton.BackColor;

            Vector pos = new Vector((double)lightX.Value, (double)lightY.Value, (double)lightZ.Value);

            Light light = new Light(pos, color, inten, att);
            lights.Add(light);

            addLightToList(light);

        }

        private void lightDeleteButton_Click(object sender, EventArgs e)
        {
            int index = lightsListBox.SelectedIndex;
            if (index == -1) return;
            lightsListBox.Items.RemoveAt(index);
            lights.RemoveAt(index);

        }

        private void lightEditButton_Click(object sender, EventArgs e)
        {
            int index = lightsListBox.SelectedIndex;
            if (index == -1) return;

            Light light = lights[index];

            light.intensity = (double)intensity.Value;
            light.attentuation = (double)attentuation.Value;
            light.color = colorButton.BackColor;

            light.position = new Vector((double)lightX.Value, (double)lightY.Value, (double)lightZ.Value);
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
                colorButton.BackColor = colorDialog.Color;
        }

        private void Form_SizeChanged(object sender, EventArgs e)
        {
            renderer.aspect = (double)dbm.Width / (double)dbm.Height;
            lightX.Maximum = dbm.Width - 1;
            lightY.Maximum = dbm.Height - 1;
        }
    }
}
