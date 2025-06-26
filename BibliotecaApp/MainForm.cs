namespace BibliotecaApp
{
    public class MainForm : Form
    {
        private Panel navPanel;
        private Panel contentPanel;

        public MainForm()
        {
            this.Text = "Sistema Biblioteca";
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            navPanel = new Panel { Dock = DockStyle.Left, Width = 200, BackColor = System.Drawing.Color.SteelBlue };
            contentPanel = new Panel { Dock = DockStyle.Fill };

            var btnInicio = CreateNavButton("Início", 0, () => LoadPage(new InicioPage()));
            var btnCadastroLivro = CreateNavButton("Cadastro Livro", 1, () => LoadPage(new CadastroLivroPage()));
            var btnCadastroUsuario = CreateNavButton("Cadastro Usuário", 2, () => LoadPage(new CadastroUsuarioPage()));
            var btnLocacao = CreateNavButton("Locação", 3, () => LoadPage(new LocacaoPage()));

            navPanel.Controls.AddRange(new Control[] { btnInicio, btnCadastroLivro, btnCadastroUsuario, btnLocacao });
            Controls.Add(contentPanel);
            Controls.Add(navPanel);

            LoadPage(new InicioPage());
        }

        private Button CreateNavButton(string text, int index, Action onClick)
        {
            var btn = new Button
            {
                Text = text,
                Width = 200,
                Height = 60,
                Top = 60 * index,
                FlatStyle = FlatStyle.Flat,
                BackColor = System.Drawing.Color.LightSteelBlue
            };
            btn.Click += (s, e) => onClick();
            return btn;
        }

        private void LoadPage(Form page)
        {
            contentPanel.Controls.Clear();
            page.TopLevel = false;
            page.FormBorderStyle = FormBorderStyle.None;
            page.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(page);
            page.Show();
        }
    }
    public static class Estilos
    {
        public static void AplicarEstiloFormulario(Form form)
        {
            form.BackColor = Color.White;
            form.Font = new Font("Segoe UI", 10F);
        }

        public static TableLayoutPanel CriarFormularioLayout(params (string label, Control input)[] campos)
        {
            var layout = new TableLayoutPanel
            {
                ColumnCount = 2,
                RowCount = campos.Length,
                Left = 200,
                Top = 30,
                Width = 400,
                AutoSize = true,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.None
            };

            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));

            for (int i = 0; i < campos.Length; i++)
            {
                layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
                var label = new Label
                {
                    Text = campos[i].label,
                    TextAlign = ContentAlignment.MiddleRight,
                    Dock = DockStyle.Fill,
                    BackColor = Color.Transparent
                };
                layout.Controls.Add(label, 0, i);
                layout.Controls.Add(campos[i].input, 1, i);
            }

            return layout;
        }

        public static Button CriarBotao(string texto)
        {
            return new Button
            {
                Text = texto,
                Width = 200,
                Height = 35,
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Margin = new Padding(0, 20, 0, 0)
            };
        }

        public static TextBox CriarTextBox(int width = 300)
        {
            return new TextBox
            {
                Width = width
            };
        }

        public static ComboBox CriarComboBox(int width = 300)
        {
            return new ComboBox
            {
                Width = width,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
        }
    }
}