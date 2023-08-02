using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using nl.florentine.processing.FileManager;
using nl.florentine.processing.FileNotFoundException;
using nl.florentine.processing.PathController;

namespace nl.florentine.ui
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Execute_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null && textBox2.Text != null)
            {

                this.progressBar1.Visible = true;
                this.progressBar1.Minimum = 1;
                Console.WriteLine(this.progressBar1.Visible.ToString() + this.progressBar1.Minimum.ToString());
                // initialise progress bar

                string replace = textBox1.Text;
                string replacement = textBox2.Text;
                string pathStr = currentFolderSelected;
                Console.WriteLine(replace + replacement + pathStr);
                // tie replacement, replace and path string to values based on elements

                PathController pathController = new PathController();
                List<String> path = pathController.seperatePath(pathStr);
                Console.WriteLine(path[0]);
                // instance path controller and seperate path string for execution

                FileManager manager = new FileManager();
                ArrayList folder = manager.indexFolder(pathStr);
                ArrayList targets = manager.queryIndex(folder, replace);
                // instance file manager, declare files in folder and targets in folder with indexFolder and queryIndex methods

                this.progressBar1.Maximum = targets.Count;
                // ArgumentOutOfRangeException if no files found
                this.progressBar1.Value = 1;
                this.progressBar1.Step = 1;
                Console.WriteLine(this.progressBar1.Value.ToString() + this.progressBar1.Step.ToString());
                // make the progress bar work

                if (replace == "rick" && replacement == "roll") {
                    System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=xvFZjo5PgG0");
                }

                int count = 0;

                foreach (string target in targets)
                {
                    try
                    {
                        IEnumerable<String> preDest = pathController.seperatePath(target);

                        var n = 1;
                        var it = preDest.GetEnumerator();
                        bool hasRemainingItems = false;
                        var cache = new Queue<string>(n + 1);
                        var dest = "";

                        do
                        {
                            if (hasRemainingItems = it.MoveNext())
                            {
                                cache.Enqueue(it.Current);
                                if (cache.Count > n)
                                    dest = cache.Dequeue();

                            }
                        } while (hasRemainingItems);

                        string newName = Regex.Replace(pathController.seperatePath(target)[pathController.seperatePath(target).Count - 1], '/' + replace + "/gmi", replacement);
                        string destPath = dest + '/' + newName;

                        if (manager.processFile(target, destPath.Substring(1), currentFileExtensionSelected) is InternalException)
                        {
                            label7.Text = manager.processFile(target, destPath.Substring(1), currentFileExtensionSelected).Message;
                            throw (InternalException)manager.processFile(target, destPath.Substring(1), currentFileExtensionSelected);
                        } else if (manager.processFile(target, destPath.Substring(1), currentFileExtensionSelected) is FileNotFoundException)
                        {
                            label7.Text = manager.processFile(target, destPath.Substring(1), currentFileExtensionSelected).Message;
                            throw (FileNotFoundException)manager.processFile(target, destPath.Substring(1), currentFileExtensionSelected);
                        }

                        Console.WriteLine(target.Split('/')[target.Split('/').Length - 1]);
                        Console.WriteLine(target.Split('/'));
                        progressBar1.PerformStep();
                        label5.Text = "Successfully processed " + (count + 1) + " files";
                    }
                    catch (System.IO.FileNotFoundException)
                    {
                        Console.WriteLine(pathStr + replace + '/', pathController.generatePath(pathStr, replacement));
                        Console.WriteLine(target);
                        Console.WriteLine("exception :(");
                    }

                    // process all files in predeclared vars and track progress with progress bar
                }


            }
        }


        private void folderBrowserDialog1_FileOk(object sender, CancelEventArgs e)
        {
            this.label4.Text = folderBrowserDialog1.SelectedPath;
            Console.WriteLine(folderBrowserDialog1.SelectedPath);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_selectedIndexChanged(object sender, EventArgs e)
        {
            currentFileExtensionSelected = (string)this.comboBox1.SelectedValue;
            Console.WriteLine(currentFileExtensionSelected);
        }


        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                currentFolderSelected = folderBrowserDialog1.SelectedPath;
                label4.Text = currentFolderSelected;
            } 
        }
    }
}
