using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Jordan_Titus_ST10082034_PROG7312
{
    internal class Line
    {
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }

        public Line(Point startPoint, Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
        }
    }

    internal class QuestionAnswerPair
    {
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }

        public QuestionAnswerPair(string question, string correctAnswer)
        {
            Question = question;
            CorrectAnswer = correctAnswer;
        }
    }
    public partial class IdentifyingAreas_Control : UserControl
    {
        // Variables to manage UI components and data
        private Panel selectedQuestion = null;
        private Panel selectedAnswer = null;
        private List<Panel> firstColumnPanels;
        private List<Panel> secondColumnPanels;
        private int QALines = 0;
        private List<Line> lines = new List<Line>();
        private List<string> firstColumnItems;
        private List<string> secondColumnItems;
        private List<string> correctAnswers;
        private bool matchDescriptionsToCallNumbers;
        //Dictionary
        private Dictionary<string, string> DeweyDictionary;
        private Dictionary<Panel, bool> QAJoiningLine = new Dictionary<Panel, bool>();
        private Dictionary<string, string> QADictonary = new Dictionary<string, string>();

        public IdentifyingAreas_Control()
        {
            InitializeComponent();
            // Initialize the control and data
            Start();
        }

        // Initialize data and UI components
        private void Start()
        {
            // Initialize various methods
            DeweyDiction();
            ColoumnItems();
            Panels();            
        }

        // Define the UI panels representing the first and second columns
        private void Panels()
        {
            firstColumnPanels = new List<Panel>
            {
                pnlLeft1,
                pnlLeft2,
                pnlLeft3,
                pnlLeft4
            };

            secondColumnPanels = new List<Panel>
            {
                pnlRight1,
                pnlRight2,
                pnlRight3,
                pnlRight4,
                pnlRight5,
                pnlRight7,
                pnlRight6
            };

            AttachMouseClickEventHandlers(firstColumnPanels, clmLeft_Click);
            AttachMouseClickEventHandlers(secondColumnPanels, clmRight_Click);

            // Initialize the state of question line drawings
            foreach (var panel in firstColumnPanels)
            {
                QAJoiningLine[panel] = false;
            }
        }
        private void DeweyDiction()
        {
            DeweyDictionary = new Dictionary<string, string>
            {
                { "000", "Computer Science, Information & general Works" },
                { "100", "Philosophy" },
                { "200", "Religion" },
                { "300", "Social Sciences" },
                { "400", "Language" },
                { "500", "Science" },
                { "600", "Technology" },
                { "700", "Art & Recreation" },
                { "800", "Literature" },
                { "900", "History & geography" }
            };
        }

        // Logic for coloumns matching
        //Apparently not working, but I don't know why
        private void ColoumnItems()
        {
            // Define the items that should be displayed in the first column
            List<string> itemsForFirstColumn;

            // Randomly choose the matching scenario: descriptions to call numbers or vice versa
            matchDescriptionsToCallNumbers = new Random().Next(2) == 0; // 0 or 1

            if (matchDescriptionsToCallNumbers)
            {
                // Matching descriptions to call numbers
                itemsForFirstColumn = DeweyDictionary.Values.ToList();
            }
            else
            {
                // Matching call numbers to descriptions
                itemsForFirstColumn = DeweyDictionary.Keys.ToList();
            }

            // Shuffle the list of items for the first column
            itemsForFirstColumn = itemsForFirstColumn.OrderBy(x => Guid.NewGuid()).ToList();

            // Initialize the first column with 4 random items
            firstColumnItems = itemsForFirstColumn.Take(4).ToList();

            // Initialize the second column with 7 possible answers (4 correct, 3 incorrect)
            secondColumnItems = new List<string>();
            correctAnswers = new List<string>();
            //Clear the dictionary
            QADictonary.Clear(); 

            foreach (var item in firstColumnItems)
            {
                if (matchDescriptionsToCallNumbers)
                {
                    // Use descriptions as questions
                    string callNumber = DeweyDictionary.First(kv => kv.Value == item).Key;
                    secondColumnItems.Add(callNumber);

                    // Store the correct answer (description)
                    correctAnswers.Add(item);
                }
                else
                {
                    // Use call numbers as questions
                    string description = DeweyDictionary[item];
                    secondColumnItems.Add(description);

                    // Store the correct answer (description)
                    correctAnswers.Add(description);
                }

                // Add to the linked dictionary
                QADictonary.Add(item, string.Empty);
            }

            // Add 3 incorrect items (exclude those used for correct answers)
            var incorrectItems = matchDescriptionsToCallNumbers
                ? DeweyDictionary.Keys.Except(secondColumnItems).OrderBy(x => Guid.NewGuid()).Take(3)
                : DeweyDictionary.Values.Except(secondColumnItems).OrderBy(x => Guid.NewGuid()).Take(3);

            secondColumnItems.AddRange(incorrectItems);

            // Shuffle the second column items
            secondColumnItems = secondColumnItems.OrderBy(x => Guid.NewGuid()).ToList();
        }

        //Method to create labels
        private void CreateLabels(List<string> items, List<Panel> columns)
        {
            for (int i = 0; i < items.Count && i < columns.Count; i++)
            {
                // Create labels within the specified column panel
                Label label = new Label
                {
                    Text = items[i],
                    AutoSize = true,
                    ForeColor = Color.Black,
                    Enabled = false,
                    Dock = DockStyle.Top // Stacked vertically within the panel
                };
                columns[i].Tag = label.Text;
                columns[i].Controls.Add(label);
            }
        }
        
        //Method for matching columns
        private void MatchColumn_Control_Load(object sender, EventArgs e)
        {
            DeweyDiction();
            ColoumnItems();

            //Labels for Left Panels
            CreateLabels(firstColumnItems, new List<Panel> { pnlLeft1, pnlLeft2, pnlLeft3, pnlLeft4 });

            //Labels for right panels
            CreateLabels(secondColumnItems, new List<Panel> { pnlRight1, pnlRight2, pnlRight3, pnlRight4, pnlRight5, pnlRight6, pnlRight7 });
            AttachMouseClickEventHandlers(new List<Panel> { pnlLeft1, pnlLeft2, pnlLeft3, pnlLeft4 }, clmLeft_Click);
            AttachMouseClickEventHandlers(new List<Panel> { pnlRight1, pnlRight2, pnlRight3, pnlRight4, pnlRight5, pnlRight6, pnlRight7 }, clmRight_Click);
        }
        // Attach mouse click event handlers to the specified panels
        private void AttachMouseClickEventHandlers(List<Panel> panels, MouseEventHandler handler)
        {
            foreach (var panel in panels)
            {
                if (panel != null)
                {
                    panel.MouseClick += handler;
                }
            }
        }
        //Method to clear the labels if the user wants to play again
        private void ClearLabels(List<Panel> columns)
        {
            foreach (var column in columns)
            {
                foreach (Control control in column.Controls)
                {
                    if (control is Label)
                    {
                        column.Controls.Remove(control);
                        // Dispose of the label control
                        control.Dispose(); 
                    }
                }
            }
        }

        // Reset the control and enable UI panels
        private void Reset()
        {
            QALines = 0;
            ColoumnItems();
            QAJoiningLine.Clear();
            QADictonary.Clear();

            // Clear labels from both first and second column panels
            ClearLabels(new List<Panel> { pnlLeft1, pnlLeft2, pnlLeft3, pnlLeft4 });
            ClearLabels(new List<Panel> { pnlRight1, pnlRight2, pnlRight3, pnlRight4, pnlRight5, pnlRight6, pnlRight7 });

            // Populate labels for the first and second column panels
            CreateLabels(firstColumnItems, new List<Panel> { pnlLeft1, pnlLeft2, pnlLeft3, pnlLeft4 });
            CreateLabels(secondColumnItems, new List<Panel> { pnlRight1, pnlRight2, pnlRight3, pnlRight4, pnlRight5, pnlRight6, pnlRight7 });
        }

        // Enable all question-answer panels
        private void EnablePanels()
        {
            foreach (var panel in firstColumnPanels)
            {
                panel.Enabled = true;
            }

            foreach (var panel in secondColumnPanels)
            {
                panel.Enabled = true;
            }
        }

        // Clear all drawn lines on the main panel
        private void ClearAllLines()
        {
            lines.Clear();
            pnlMain.Invalidate(); 
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearAllLines();
            Reset();
            EnablePanels();
        }

        private void clmLeft_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Panel clickedPanel = sender as Panel;

                if (clickedPanel != null)
                {
                    if (selectedQuestion != null)
                    {
                        selectedQuestion.BackColor = Color.DimGray;
                    }

                    selectedQuestion = clickedPanel;
                    selectedQuestion.BackColor = Color.White; // Set the selected question's color
                }
            }
        }

        private void clmRight_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Panel clickedPanel = sender as Panel;

                if (clickedPanel != null)
                {
                    selectedAnswer = clickedPanel;

                    if (selectedQuestion != null && selectedAnswer != null)
                    {
                        DrawLine(selectedQuestion, selectedAnswer);

                        //This line keeps coming up as null. I am not certain why.
                        //It means that my panels are not getting populated with text, but I can't find out why that is
                        //Null error
                        //QADictonary[selectedQuestion.Tag.ToString()] = selectedAnswer.Tag.ToString();
                        QAJoiningLine[selectedQuestion] = true;
                        //Disables the buttons so they cannot be clicked again
                        selectedQuestion.Enabled = false;
                        selectedAnswer.Enabled = false;
                        //To show the user that they have been selected
                        selectedAnswer.BackColor = Color.DimGray;
                        selectedQuestion.BackColor = Color.DimGray;
                        selectedQuestion = null;
                        selectedAnswer = null;
                         
                        if (QALines == 4)
                        {
                            CheckAnswers();
                            return;
                        }
                    }
                }
            }
        }

        //Verify the users answers
        //Chatgpt helped here
        private void CheckAnswers()
        {
            int correctCount = 0;
            int totalQuestions = firstColumnItems.Count;

            for (int i = 0; i < firstColumnItems.Count; i++)
            {
                string questionText = firstColumnItems[i];
                string selectedAnswerText = QADictonary[questionText];
                string correctAnswerText;

                if (matchDescriptionsToCallNumbers)
                {
                    correctAnswerText = DeweyDictionary.FirstOrDefault(kv => kv.Value == questionText).Key;
                }
                else
                {
                    correctAnswerText = DeweyDictionary[questionText];
                }

                if (correctAnswerText != null && selectedAnswerText == correctAnswerText)
                {
                    correctCount++;
                }
            }
            //Simple pop-up message to tell the user the answer
            string message = $"You answered {correctCount} out of {totalQuestions} questions correctly.";
            MessageBox.Show(message, "Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Draws a line between column 1 and 2
        /// <summary>
        /// Source: https://learn.microsoft.com/en-us/dotnet/desktop/winforms/advanced/how-to-use-a-pen-to-draw-lines?view=netframeworkdesktop-4.8
        /// </summary>
        /// <param name="startPanel"></param>
        /// <param name="endPanel"></param>
        private void DrawLine(Panel startPanel, Panel endPanel)
        {
            using (Pen pen = new Pen(Color.Firebrick, 4))
            {
                pnlMain.CreateGraphics().SmoothingMode = SmoothingMode.AntiAlias;

                Point startPoint = new Point(startPanel.Right, startPanel.Top + startPanel.Height / 2);
                Point endPoint = new Point(endPanel.Left, endPanel.Top + endPanel.Height / 2);

                pnlMain.CreateGraphics().DrawLine(pen, startPoint, endPoint);

                QALines++;

                lines.Add(new Line(startPoint, endPoint));
            }
        }
    }
}



//Sources:
//https://docs.microsoft.com/en-us/dotnet/desktop/winforms/ - Used throughout the document
//Panel specific: https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/panel-control-windows-forms?view=netframeworkdesktop-4.8
//ChatGPT for various error fixes and code optimizsation
//Dictionary: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=net-7.0
