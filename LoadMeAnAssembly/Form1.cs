using Filters;
using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace LoadMeAnAssembly
{
    public partial class Form1 : Form
    {
        IFilter _currentFilter;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = _currentFilter.Apply(pictureBox1.Image);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var assembly = Assembly.GetExecutingAssembly();
            LoadFiltersFromAssembly(assembly);
        }

        private void LoadFiltersFromAssembly(Assembly assembly)
        {
            var filters = assembly.GetTypes().Where(x => x != typeof(IFilter) && typeof(IFilter).IsAssignableFrom(x));
            foreach (var filter in filters)
            {
                listBox1.Items.Add(Activator.CreateInstance(filter));
            }
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            _currentFilter = (IFilter)listBox1.SelectedItem;
            btnFilter.Enabled = true;
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (var file in files)
            {
                try
                {
                    var assembly = Assembly.LoadFile(file);
                    LoadFiltersFromAssembly(assembly);
                }
                catch
                {

                }
            }
        }
    }
}
