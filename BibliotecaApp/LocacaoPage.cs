using MySql.Data.MySqlClient;

namespace BibliotecaApp
{
    public class LocacaoPage : Form
    {
        private ComboBox cmbUsuarios, cmbLivros;
        private DateTimePicker dtpLocacao, dtpDevolucao;
        private Button btnSalvar;

        public LocacaoPage()
        {
            Estilos.AplicarEstiloFormulario(this);

            cmbUsuarios = Estilos.CriarComboBox();
            cmbLivros = Estilos.CriarComboBox();
            dtpLocacao = new DateTimePicker { Width = 300 };
            dtpDevolucao = new DateTimePicker { Width = 300 };

            btnSalvar = Estilos.CriarBotao("Registrar Locação");
            btnSalvar.Click += BtnSalvar_Click;

            var layout = Estilos.CriarFormularioLayout(
                ("Usuário:", cmbUsuarios),
                ("Livro:", cmbLivros),
                ("Data Locação:", dtpLocacao),
                ("Data Devolução:", dtpDevolucao)
            );

            Controls.Add(layout);

            var painelBtn = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50
            };
            btnSalvar.Anchor = AnchorStyles.None;
            btnSalvar.Left = (layout.Width - btnSalvar.Width) / 2;
            painelBtn.Controls.Add(btnSalvar);
            Controls.Add(painelBtn);

            LoadData();
        }

        private void LoadData()
        {
            using var conn = new MySqlConnection(Conexao.ConnectionString);
            conn.Open();

            var cmdUsuarios = new MySqlCommand("SELECT id, nome FROM usuarios", conn);
            using var readerUsuarios = cmdUsuarios.ExecuteReader();
            while (readerUsuarios.Read())
                cmbUsuarios.Items.Add(new { Text = readerUsuarios["nome"].ToString(), Value = readerUsuarios["id"] });

            readerUsuarios.Close();

            var cmdLivros = new MySqlCommand("SELECT id, titulo FROM livros", conn);
            using var readerLivros = cmdLivros.ExecuteReader();
            while (readerLivros.Read())
                cmbLivros.Items.Add(new { Text = readerLivros["titulo"].ToString(), Value = readerLivros["id"] });
        }

        private void BtnSalvar_Click(object sender, System.EventArgs e)
        {
            try
            {
                dynamic usuario = cmbUsuarios.SelectedItem;
                dynamic livro = cmbLivros.SelectedItem;

                using var conn = new MySqlConnection(Conexao.ConnectionString);
                conn.Open();
                var cmd = new MySqlCommand("INSERT INTO locacoes (id_usuario, id_livro, data_locacao, data_devolucao) VALUES (@uid, @lid, @loc, @dev)", conn);
                cmd.Parameters.AddWithValue("@uid", usuario?.Value);
                cmd.Parameters.AddWithValue("@lid", livro?.Value);
                cmd.Parameters.AddWithValue("@loc", dtpLocacao.Value.Date);
                cmd.Parameters.AddWithValue("@dev", dtpDevolucao.Value.Date);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Locação registrada com sucesso!");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Erro ao registrar locação: " + ex.Message);
            }
        }
    }
}