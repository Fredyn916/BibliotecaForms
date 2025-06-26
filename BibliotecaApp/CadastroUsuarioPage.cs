using MySql.Data.MySqlClient;

namespace BibliotecaApp
{
    public class CadastroUsuarioPage : Form
    {
        private TextBox txtNome, txtEmail, txtSenha;
        private ComboBox cmbTipo;
        private Button btnSalvar;

        public CadastroUsuarioPage()
        {
            Estilos.AplicarEstiloFormulario(this);

            txtNome = Estilos.CriarTextBox();
            txtEmail = Estilos.CriarTextBox();
            txtSenha = Estilos.CriarTextBox();
            txtSenha.UseSystemPasswordChar = true;
            cmbTipo = Estilos.CriarComboBox();
            cmbTipo.Items.AddRange(new[] { "admin", "autor", "leitor" });

            btnSalvar = Estilos.CriarBotao("Salvar");
            btnSalvar.Click += BtnSalvar_Click;

            var layout = Estilos.CriarFormularioLayout(
                ("Nome:", txtNome),
                ("Email:", txtEmail),
                ("Senha:", txtSenha),
                ("Tipo:", cmbTipo)
            );

            Controls.Add(layout);
            Controls.Add(btnSalvar);
        }

        private void BtnSalvar_Click(object sender, System.EventArgs e)
        {
            try
            {
                using var conn = new MySqlConnection(Conexao.ConnectionString);
                conn.Open();
                var cmd = new MySqlCommand("INSERT INTO usuarios (nome, tipo, email, senha) VALUES (@nome, @tipo, @email, @senha)", conn);
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@tipo", cmbTipo.SelectedItem?.ToString());
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@senha", txtSenha.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Usuário cadastrado com sucesso!");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar usuário: " + ex.Message);
            }
        }
    }
}