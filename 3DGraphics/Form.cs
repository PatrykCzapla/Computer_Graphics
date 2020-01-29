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
        public static bool interpolatiton = true;

        private List<Model> models = new List<Model>();
        private List<Scene> scenes = new List<Scene>();
        private List<Camera> cameras = new List<Camera>();

        private Camera currentCam;
        private Scene currentScene;
        private Model currentModel;

        private Renderer renderer;

        private double prevX = -1;
        private double prevY = -1;

        private int FPS = 0;
        private int counter = 0;

        public Form()
        {
            InitializeComponent();
            dbm = new DirectBitmap(drawingPictureBox.Width, drawingPictureBox.Height);
            drawingPictureBox.Image = dbm.Bitmap;

            currentCam = new Camera(new Vector(0, 0, 10), new Vector(0, 0, 0), 1, 1000, 1);
            currentScene = new Scene(models, currentCam);
            scenes.Add(currentScene);
            cameras.Add(currentCam);

            camerasListBox.Items.Add("Camera 0");

            renderer = new Renderer();

            fpsTimer.Start();
        }

        private void drawAll()
        {
            FPS++;

            dbm.Dispose();
            dbm = new DirectBitmap(drawingPictureBox.Width, drawingPictureBox.Height);

            renderer.render(currentScene);
            drawingPictureBox.Image = dbm.Bitmap;
            drawingPictureBox.Invalidate();
        }

        private void cuboidButton_Click(object sender, EventArgs e)
        {
            double x = (double)cuboidX.Value;
            double y = (double)cuboidY.Value;
            double z = (double)cuboidZ.Value;

            Cuboid cuboid = new Cuboid();
            Mesh mesh = cuboid.createCuboid(x, y, z);
            Model model = new Model(mesh, "Cuboid");

            model.position.values[0] = (double)positionX.Value;
            model.position.values[1] = -(double)positionY.Value;
            model.position.values[2] = (double)positionZ.Value;

            model.rotation.values[0] = (double)rotationX.Value;
            model.rotation.values[1] = (double)rotationY.Value;
            model.rotation.values[2] = (double)rotationZ.Value;

            model.scale.values[0] = (double)scaleX.Value;
            model.scale.values[1] = (double)scaleY.Value;
            model.scale.values[2] = (double)scaleZ.Value;

            foreach (Scene s in scenes)
                s.models.Add(model);

            addModelToList(model);

            drawAll();
        }

        private void coneButton_Click(object sender, EventArgs e)
        {
            int div = (int)coneDivision.Value;
            double radius = (double)coneRadius.Value;
            double height = (double)coneHeight.Value;

            Cone cone = new Cone();
            Mesh mesh = cone.createCone(div, radius, height);
            Model model = new Model(mesh, "Cone");

            model.position.values[0] = (double)positionX.Value;
            model.position.values[1] = -(double)positionY.Value;
            model.position.values[2] = (double)positionZ.Value;

            model.rotation.values[0] = (double)rotationX.Value;
            model.rotation.values[1] = (double)rotationY.Value;
            model.rotation.values[2] = (double)rotationZ.Value;

            model.scale.values[0] = (double)scaleX.Value;
            model.scale.values[1] = (double)scaleY.Value;
            model.scale.values[2] = (double)scaleZ.Value;

            foreach (Scene s in scenes)
                s.models.Add(model);

            addModelToList(model);

            drawAll();
        }

        private void sphereButton_Click(object sender, EventArgs e)
        {
            double radius = (double)sphereRadius.Value;
            int theta = (int)sphereTheta.Value;
            int phi = (int)spherePhi.Value;

            Sphere sphere = new Sphere(radius);
            Mesh mesh = sphere.createSphere(phi, theta);
            Model model = new Model(mesh, "Sphere");

            model.position.values[0] = (double)positionX.Value;
            model.position.values[1] = -(double)positionY.Value;
            model.position.values[2] = (double)positionZ.Value;

            model.rotation.values[0] = (double)rotationX.Value;
            model.rotation.values[1] = (double)rotationY.Value;
            model.rotation.values[2] = (double)rotationZ.Value;

            model.scale.values[0] = (double)scaleX.Value;
            model.scale.values[1] = (double)scaleY.Value;
            model.scale.values[2] = (double)scaleZ.Value;

            foreach (Scene s in scenes)
                s.models.Add(model);

            addModelToList(model);

            drawAll();
        }

        private void cylinderButton_Click(object sender, EventArgs e)
        {
            int div = (int)cylinderDivision.Value;
            double height = (double)cylinderHeight.Value;
            double radius = (double)cylinderRadius.Value;

            Cylinder cylinder = new Cylinder();
            Mesh mesh = cylinder.createCylinder(div, radius, height);
            Model model = new Model(mesh, "Cylinder");

            model.position.values[0] = (double)positionX.Value;
            model.position.values[1] = -(double)positionY.Value;
            model.position.values[2] = (double)positionZ.Value;

            model.rotation.values[0] = (double)rotationX.Value;
            model.rotation.values[1] = (double)rotationY.Value;
            model.rotation.values[2] = (double)rotationZ.Value;

            model.scale.values[0] = (double)scaleX.Value;
            model.scale.values[1] = (double)scaleY.Value;
            model.scale.values[2] = (double)scaleZ.Value;

            foreach (Scene s in scenes)
                s.models.Add(model);

            addModelToList(model);

            drawAll();
        }

        private void addCameraToList(Camera cam)
        {
            camerasListBox.Items.Add("Camera " + camerasListBox.Items.Count);
        }

        private void addModelToList(Model model)
        {
            modelsListBox.Items.Add(model.name + " " + +modelsListBox.Items.Count);
        }


        private void position_ValueChanged(object sender, EventArgs e)
        {
            if (currentModel == null) return;
            Vector position = new Vector((double)positionX.Value, -(double)positionY.Value, (double)positionZ.Value);
            currentModel.position = position;
            drawAll();
        }

        private void rotation_ValueChanged(object sender, EventArgs e)
        {
            if (currentModel == null) return;
            Vector rotation = new Vector((double)rotationX.Value, (double)rotationY.Value, (double)rotationZ.Value);
            currentModel.rotation = rotation;
            drawAll();
        }

        private void scale_ValueChanged(object sender, EventArgs e)
        {
            if (currentModel == null) return;
            Vector scale = new Vector((double)scaleX.Value, (double)scaleY.Value, (double)scaleZ.Value);
            currentModel.scale = scale;
            drawAll();
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
            drawAll();
        }

        private void fillCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            fill = !fill;
            drawAll();
        }

        private void zBufferingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            zBuffer = !zBuffer;
            drawAll();
        }

        private void cullingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            backfaceCulling = !backfaceCulling;
            drawAll();
        }

        private void interpolationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            interpolatiton = !interpolatiton;
            drawAll();
        }

        private void camerasListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = camerasListBox.SelectedIndex;

            if (index == -1) return;

            currentCam = cameras[index];

            currentScene = scenes.Find(s => s.camera == currentCam);

            drawAll();
        }

        private void cameraDeleteButton_Click(object sender, EventArgs e)
        {
            int index = camerasListBox.SelectedIndex;
            if (index == -1 || cameras.Count == 1) return;
            modelsListBox.Items.RemoveAt(index);
            models.RemoveAt(index);

            currentCam = cameras[0];

            currentScene = scenes.Find(s => s.camera == currentCam);

            drawAll();
        }

        private void cameraButton_Click(object sender, EventArgs e)
        {
            double fov = (double)cameraFOV.Value;
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
            currentScene = new Scene(models, newCam);
            scenes.Add(currentScene);
            currentCam = newCam;
            drawAll();
        }

        private void moveCameraX(Camera cam, double x)
        {
            cameras.Find(c => c==cam).position.values[0] += x;
            drawAll();
        }

        private void moveCameraY(Camera cam, double y)
        {
            cameras.Find(c => c == cam).position.values[1] += y;
            drawAll();
        }

        private void moveCameraZ(Camera cam, double z)
        {
            cameras.Find(c => c == cam).position.values[2] += z;
            drawAll();
        }

        private void drawingPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            prevX = e.X;
            prevY = e.Y;
        }

        private void drawingPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            counter++;
            if (counter != 10) return;
            counter = 0;
            if (prevY == -1) return;
            double dx = e.X - prevX;
            double dy = e.Y - prevY;
            if (dx != 0) moveCameraX(currentCam, dx / drawingPictureBox.Width);
            if (dy != 0) moveCameraY(currentCam, dy / drawingPictureBox.Height);
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
            openFileDialog.Filter = "TXT Files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.CheckFileExists == false) return;
                FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                scenes = new List<Scene>();

                scenes = (List<Scene>)binaryFormatter.Deserialize(fileStream);

                models = scenes.First().models;

                cameras = new List<Camera>();

                foreach(Scene s in scenes)
                {
                    cameras.Add(s.camera);
                }

                camerasListBox.Items.Clear();

                currentScene = scenes.First();
                currentModel = null;
                currentCam = currentScene.camera;

                foreach (Model m in models)
                    addModelToList(m);

                foreach (Camera c in cameras)
                    addCameraToList(c);

                drawAll();

            }
        }

        private void cameraEditButton_Click(object sender, EventArgs e)
        {
            int index = camerasListBox.SelectedIndex;
            if (index == -1) return;

            Camera cam = cameras[index];

            double fov = (double)cameraFOV.Value;
            double far = (double)cameraFar.Value;
            double close = (double)cameraClose.Value;

            cam.fov = fov;
            cam.far = far;
            cam.close = close;

            currentCam = cam;
            currentScene = scenes.Find(s => s.camera == currentCam);

            drawAll();
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

                        Cuboid cuboid = new Cuboid();
                        Mesh mesh = cuboid.createCuboid(x, y, z);
                        Model newModel = new Model(mesh, "Cuboid");

                        newModel.position.values[0] = (double)positionX.Value;
                        newModel.position.values[1] = -(double)positionY.Value;
                        newModel.position.values[2] = (double)positionZ.Value;

                        newModel.rotation.values[0] = (double)rotationX.Value;
                        newModel.rotation.values[1] = (double)rotationY.Value;
                        newModel.rotation.values[2] = (double)rotationZ.Value;

                        newModel.scale.values[0] = (double)scaleX.Value;
                        newModel.scale.values[1] = (double)scaleY.Value;
                        newModel.scale.values[2] = (double)scaleZ.Value;

                        foreach (Scene s in scenes)
                            s.models.Insert(index, newModel);


                        drawAll();

                        break;
                    }
                case "Cone":
                    {
                        int div = (int)coneDivision.Value;
                        double radius = (double)coneRadius.Value;
                        double height = (double)coneHeight.Value;

                        Cone cone = new Cone();
                        Mesh mesh = cone.createCone(div, radius, height);
                        Model newModel = new Model(mesh, "Cone");

                        newModel.position.values[0] = (double)positionX.Value;
                        newModel.position.values[1] = -(double)positionY.Value;
                        newModel.position.values[2] = (double)positionZ.Value;

                        newModel.rotation.values[0] = (double)rotationX.Value;
                        newModel.rotation.values[1] = (double)rotationY.Value;
                        newModel.rotation.values[2] = (double)rotationZ.Value;

                        newModel.scale.values[0] = (double)scaleX.Value;
                        newModel.scale.values[1] = (double)scaleY.Value;
                        newModel.scale.values[2] = (double)scaleZ.Value;

                        foreach (Scene s in scenes)
                            s.models.Insert(index, newModel);

                        drawAll();

                        break;
                    }
                case "Cylinder":
                    {
                        int div = (int)cylinderDivision.Value;
                        double height = (double)cylinderHeight.Value;
                        double radius = (double)cylinderRadius.Value;

                        Cylinder cylinder = new Cylinder();
                        Mesh mesh = cylinder.createCylinder(div, radius, height);
                        Model newModel = new Model(mesh, "Cylinder");

                        newModel.position.values[0] = (double)positionX.Value;
                        newModel.position.values[1] = -(double)positionY.Value;
                        newModel.position.values[2] = (double)positionZ.Value;

                        newModel.rotation.values[0] = (double)rotationX.Value;
                        newModel.rotation.values[1] = (double)rotationY.Value;
                        newModel.rotation.values[2] = (double)rotationZ.Value;

                        newModel.scale.values[0] = (double)scaleX.Value;
                        newModel.scale.values[1] = (double)scaleY.Value;
                        newModel.scale.values[2] = (double)scaleZ.Value;

                        foreach (Scene s in scenes)
                            s.models.Insert(index, newModel);

                        drawAll();
                        break;
                    }
                case "Sphere":
                    {
                        double radius = (double)sphereRadius.Value;
                        int theta = (int)sphereTheta.Value;
                        int phi = (int)spherePhi.Value;

                        Sphere sphere = new Sphere(radius);
                        Mesh mesh = sphere.createSphere(phi, theta);
                        Model newModel = new Model(mesh, "Sphere");

                        newModel.position.values[0] = (double)positionX.Value;
                        newModel.position.values[1] = -(double)positionY.Value;
                        newModel.position.values[2] = (double)positionZ.Value;

                        newModel.rotation.values[0] = (double)rotationX.Value;
                        newModel.rotation.values[1] = (double)rotationY.Value;
                        newModel.rotation.values[2] = (double)rotationZ.Value;

                        newModel.scale.values[0] = (double)scaleX.Value;
                        newModel.scale.values[1] = (double)scaleY.Value;
                        newModel.scale.values[2] = (double)scaleZ.Value;

                        foreach (Scene s in scenes)
                            s.models.Insert(index, newModel);


                        drawAll();
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
            this.Text = "3D ENGINE    FPS: " + FPS;

            FPS = 0;
        }
    }
}
