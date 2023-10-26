using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace WebCam
{
    public partial class Form1 : Form
    {
        private bool DeviceExist = false;
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void video_NewFrame(Object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap img = (Bitmap)eventArgs.Frame.Clone();
            pctCapturaImagem.Image = img;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            try
            {
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                cbbDispositivo.Items.Clear();
                if (videoDevices.Count == 0) throw new ApplicationException();

                DeviceExist = true;

                foreach (FilterInfo device in videoDevices)
                {
                    cbbDispositivo.Items.Add(device.Name);
                }
                cbbDispositivo.SelectedIndex = 0;
            }
            catch (ApplicationException)
            {
                DeviceExist = false;
                cbbDispositivo.Items.Add("Nenhum dispositivo encontrado!");
            }
        }

        private void btnCapturar_Click(object sender, EventArgs e)
        {
            if (btnCapturar.Text == "Capturar")
            {
                if (DeviceExist)
                {
                    videoSource = new VideoCaptureDevice(videoDevices[cbbDispositivo.SelectedIndex].MonikerString);
                    videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);

                    //encerra o sinal da camera
                    if (videoSource != null)
                    {
                        if (videoSource.IsRunning)
                        {
                            videoSource.SignalToStop();
                            videoSource = null;
                        }
                    }

                    videoSource.DesiredFrameSize = new Size(77, 50);
                    videoSource.DesiredFrameRate = 10;
                    videoSource.Start();

                    btnCapturar.Text = "Gravar";
                }
                else
                {
                    MessageBox.Show("Nenhum dispositivo encontrado!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (videoSource.IsRunning)
                {
                    //encerra o sinal da camera
                    if (videoSource != null)
                    {
                        if (videoSource.IsRunning)
                        {
                            videoSource.SignalToStop();
                            videoSource = null;
                        }
                    }

                    //salva a imagem
                    sfdSalvaImagem.Filter = "JPEG (*.jpg;*.jpeg;*jpeg;*.jfif)|*.jpg;*.jpeg;*jpeg;*.jfif";
                    DialogResult res = sfdSalvaImagem.ShowDialog();
                    if (res == DialogResult.OK)
                    {
                        pctCapturaImagem.Image.Save(sfdSalvaImagem.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                }
            }
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrirImg = new OpenFileDialog();
            abrirImg.InitialDirectory = ("d:\\imagens\\");
            abrirImg.FileName = "Imagem";
            abrirImg.Title = "Procurar Imagem";
            abrirImg.Filter = ("Todos os arquivos|*|*jpg|*.jpg|*jpeg|*.jpeg|*jfif|*.jfif|*png|*.png|*bmp|*.bmp|*tif|*.tif");
            abrirImg.ShowDialog();
            pctCapturaImagem.ImageLocation = (abrirImg.FileName);
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            pctCapturaImagem.Image = null;
        }
    }
}
