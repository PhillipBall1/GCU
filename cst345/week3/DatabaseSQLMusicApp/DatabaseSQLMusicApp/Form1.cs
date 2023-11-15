namespace DatabaseSQLMusicApp
{
    public partial class Form1 : Form
    {

        BindingSource albumsBindingSource = new BindingSource();
        BindingSource tracksBindingSource = new BindingSource();

        List<Album> albums = new List<Album>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AlbumsDAO albumsDAO = new AlbumsDAO();

            albumsBindingSource.DataSource = albumsDAO.GetAllAlbums();

            albums = albumsDAO.GetAllAlbums();

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

            tracksBindingSource.DataSource = albums[rowClicked].Tracks;
            dataGridView2.DataSource = tracksBindingSource;
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

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;

            int rowClicked = dataGridView.CurrentRow.Index;

            string videoURL = dataGridView.Rows[rowClicked].Cells[3].Value.ToString();

            webView21.Source = new Uri(videoURL);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int rowClicked = dataGridView2.CurrentRow.Index;
            int trackID = (int)dataGridView2.Rows[rowClicked].Cells[0].Value;

            AlbumsDAO albumsDAO = new AlbumsDAO();

            int result = albumsDAO.DeleteTrack(trackID);

            dataGridView2.DataSource = null;
            albums = albumsDAO.GetAllAlbums();
            MessageBox.Show("Result " + result);

        }
    }
}