using System;
using System.Windows;
using DevExpress.Data.Filtering;
using DevExpress.Xpf.Grid;
using DevExpress.Xpo;
using DevExpress.Xpf.Core;

namespace InstantFeedbackMode {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        
        public MainWindow() {
            InitDAL();
            // Generates test data - 100,000 records.
            GenerateTestData(100000);
            InitializeComponent();
            
            // Creates and initializes the data source which activates the Instant Feedback UI Mode.
            XPInstantFeedbackSource instantDS = new XPInstantFeedbackSource(typeof(TestObject));
            instantDS.ResolveSession += new EventHandler<ResolveSessionEventArgs>(instantDS_ResolveSession);
            instantDS.DismissSession += new EventHandler<ResolveSessionEventArgs>(instantDS_DismissSession);
            
            // Bind the grid.
            grid.ItemsSource = instantDS;
        }

        void instantDS_ResolveSession(object sender, ResolveSessionEventArgs e) {
            e.Session = new UnitOfWork();
        }

        void instantDS_DismissSession(object sender, ResolveSessionEventArgs e) {
            IDisposable session = e.Session as IDisposable;
            if (session != null) {
                session.Dispose();
            }
        }

        private static void InitDAL() {
            XpoDefault.Session = null;
            XpoDefault.DataLayer = XpoDefault.GetDataLayer(
                DevExpress.Xpo.DB.AccessConnectionProvider.GetConnectionString("test.mdb"),
                DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema
                );
        }

        private void GenerateTestData(int recordCount) {
            using (UnitOfWork s = new UnitOfWork()) {
                if (s.FindObject<TestObject>(null) != null) return;
                for (int i = 0; i < recordCount; i++) {
                    TestObject o = new TestObject(s) { HasAttachment = false, Sent = DateTime.Now, Subject = string.Format("Subject {0}", i) };
                }
                s.CommitChanges();
            }
        }
    }
}
