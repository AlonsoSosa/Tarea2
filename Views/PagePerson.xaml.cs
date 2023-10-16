

using Plugin.Media;

namespace Tarea2.Views;

public partial class PagePerson : ContentPage
{
    Plugin.Media.Abstractions.MediaFile photo = null;
    public String ImageToBase64()
    {
        if (photo != null)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                Stream stream = photo.GetStream();
                stream.CopyTo(memory);
                byte[] data = memory.ToArray();
                String base64 = Convert.ToBase64String(data);
                return base64;
            }
        }
        return null;
    }

    public byte[] ImageToArrayByte()
    {
        if (photo != null)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                Stream stream = photo.GetStream();
                stream.CopyTo(memory);
                byte[] data = memory.ToArray();

                return data;
            }
        }
        return null;
    }
    public PagePerson()
	{
		InitializeComponent();
	}

    private async void btnfoto_Clicked(object sender, EventArgs e)
    {
        photo = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
        {
            Directory = "MIALBUM",
            Name = "Foto.jpg",
            SaveToAlbum = true
        });

        if (photo != null)
        {
            foto.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
        }
    }

    private async void btnproceso_Clicked(object sender, EventArgs e)
    {
        var person = new Models.Personas
        {
            nombres = txtnombre.Text,
            apellidos = txtapellido.Text,
            fechanac = fechanac.Date,
            telefono = txttelefono.Text,
            foto = ImageToArrayByte()
        };

        if (await App.Instancia.addPerson(person) > 0)
        {
            await DisplayAlert("Aviso", "Persona Agregada", "OK");
        }
        else
        {
            await DisplayAlert("Alerta", "Ocurrio un error", "OK");
        }
    }
}