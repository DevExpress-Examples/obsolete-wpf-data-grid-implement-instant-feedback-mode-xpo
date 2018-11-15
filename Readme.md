<!-- default file list -->
*Files to look at*:

* [DataModel.cs](./CS/InstantFeedbackMode/DataModel.cs) (VB: [DataModel.vb](./VB/InstantFeedbackMode/DataModel.vb))
* [MainWindow.xaml](./CS/InstantFeedbackMode/MainWindow.xaml) (VB: [MainWindow.xaml.vb](./VB/InstantFeedbackMode/MainWindow.xaml.vb))
* [MainWindow.xaml.cs](./CS/InstantFeedbackMode/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/InstantFeedbackMode/MainWindow.xaml.vb))
<!-- default file list end -->
# How to Implement the Instant Feedback Mode (XPO)


<p>In this example, the grid is bound to an XPInstantFeedbackSource object which activates an Instant Feedback Mode. In this mode, you will no longer experience any UI freezing. Data operations will be performed asynchronously, in a background thread and both the grid and your application will be always highly responsive.</p>

<br/>


