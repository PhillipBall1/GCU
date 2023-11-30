using MySqlX.XDevAPI.Common;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace DatabaseSQLMusicApp
{
    public partial class Form1 : Form
    {
        AlbumsDAO albumsDAO = new AlbumsDAO();

        Album currentSelectedAlbum = null;

        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = albumsDAO.GetAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = albumsDAO.GetAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = albumsDAO.Search(textBox1.Text);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            string selected = grid.Rows[grid.CurrentCell.RowIndex].Cells[0].Value.ToString();
            dataGridView2.DataSource = albumsDAO.GetOne(selected).Tracks;
            currentSelectedAlbum = albumsDAO.GetOne(selected);
            try
            {
                pictureBox1.Load(grid.Rows[grid.CurrentCell.RowIndex].Cells[4].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Album a = new Album
                {
                    album_title = txt_AlbumName.Text,
                    artist = txt_ArtistName.Text,
                    year = Int32.Parse(txt_Year.Text),
                    image = txt_Image.Text,
                    description = txt_Description.Text,
                    Tracks = new List<Track>()
                };
                albumsDAO.AddOne(a);
                dataGridView1.DataSource = albumsDAO.GetAll();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            string url = grid.Rows[grid.CurrentCell.RowIndex].Cells[3].Value.ToString();

            try
            {
                webView21.Source = new Uri(url);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (currentSelectedAlbum == null) return;

            string trackID = (string)dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value;

            DialogResult dialogResult = MessageBox.Show("Do you want to remove this track " + trackID + "?", "Warning", MessageBoxButtons.YesNo);

            if (dialogResult != DialogResult.Yes) return;

            bool deleteResult = albumsDAO.DeleteOneTrack(currentSelectedAlbum, trackID);

            if (deleteResult == false) MessageBox.Show("Error Deleting");

            dataGridView2.DataSource = currentSelectedAlbum.Tracks;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (currentSelectedAlbum == null) return;

            dataGridView2.DataSource = currentSelectedAlbum.Tracks;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (currentSelectedAlbum == null) return;

            List<Track> list = new List<Track>();
            foreach(Track track in currentSelectedAlbum.Tracks) 
            {
                if (!track.title.ToLower().Contains(textBox2.Text.ToLower())) continue;
                    
                list.Add(track);
            }
            dataGridView2.DataSource=list;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (currentSelectedAlbum == null) return;

            Track track = new Track
            {
                title = txt_TrackTitle.Text,
                video_url = txt_VideoURL.Text
            };
            albumsDAO.AddTrackToAlbum(currentSelectedAlbum, track);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (currentSelectedAlbum == null) return;

            DialogResult dialogResult = MessageBox.Show("Do you want to remove this album '" + currentSelectedAlbum.album_title + "'?", "Warning", MessageBoxButtons.YesNo);

            if (dialogResult != DialogResult.Yes) return;

            int deleteResult = albumsDAO.DeleteOne(currentSelectedAlbum.ID);

            if (deleteResult < 0) MessageBox.Show("Error Deleting");

            dataGridView1.DataSource = albumsDAO.GetAll();
        }
    }
}