using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace CamaraApp
{
    public partial class Foto : ContentPage
    {
        public Foto()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            var f = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions()
            {
                Directory = "Fotos",
                Name = "mifoto.jpg"
            });

            var st = f.GetStream();
            f.Dispose();
            var l = st.Length;
            byte[] bt = new byte[l];
            st.Read(bt, 0, bt.Length);
            var upload = new UploadFile();
            await upload.SubirFoto(bt);
            MiFoto.Source = ImageSource.FromStream(() => st);
        }
    }
}
