namespace BibliotecaApp
{
    public class InicioPage : Form
    {
        public InicioPage()
        {
            BackColor = Color.WhiteSmoke;

            Label titulo = new()
            {
                Text = "📚 Sistema da Biblioteca 📚",
                Font = new Font("Segoe UI", 24F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 100,
                ForeColor = Color.SteelBlue,
                BackColor = Color.Transparent
            };

            Label subtitulo = new()
            {
                Text = "Gerencie seus livros, usuários e locações com facilidade",
                Font = new Font("Segoe UI", 14F, FontStyle.Italic),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 60,
                ForeColor = Color.DimGray,
                BackColor = Color.Transparent
            };

            PictureBox imagem = new()
            {
                Image = new Bitmap(64, 64),
                SizeMode = PictureBoxSizeMode.CenterImage,
                Dock = DockStyle.Top,
                Height = 120,
                BackColor = Color.Transparent
            };

            Label creditos = new()
            {
                Text = "Desenvolvido por Fred Marques - 2025",
                Font = new Font("Segoe UI", 10F),
                Dock = DockStyle.Bottom,
                Height = 30,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Gray,
                BackColor = Color.Transparent
            };

            Controls.Add(creditos);
            Controls.Add(subtitulo);
            Controls.Add(imagem);
            Controls.Add(titulo);
        }
    }
}