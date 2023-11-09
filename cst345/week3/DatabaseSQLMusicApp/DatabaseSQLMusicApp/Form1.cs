namespace DatabaseSQLMusicApp
{
    public partial class Form1 : Form
    {

        BindingSource albumsBindingSource = new BindingSource();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AlbumsDAO albumsDAO = new AlbumsDAO();

            albumsBindingSource.DataSource = albumsDAO.GetAllAlbums();

            dataGridView1.DataSource = albumsBindingSource;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AlbumsDAO albumsDAO = new AlbumsDAO();

            albumsBindingSource.DataSource = albumsDAO.SearchTitles(textBox1.Text);

            dataGridView1.DataSource = albumsBindingSource;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;

            int rowClicked = dataGridView.CurrentRow.Index;

            string ImageURL = dataGridView.Rows[rowClicked].Cells[4].Value.ToString();

            pictureBox1.Load(ImageURL);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Album album = new Album
            {
                AlbumName = txt_AlbumName.Text,
                ArtistName = txt_ArtistName.Text,
                Year = Int32.Parse(txt_Year.Text),
                ImageURL = txt_Image.Text,
                Description = txt_Description.Text
            };

            AlbumsDAO albumsDAO = new AlbumsDAO();
            int result = albumsDAO.AddOneALbum(album);
            MessageBox.Show(result + " new row(s) inserted");
        }
    }
}