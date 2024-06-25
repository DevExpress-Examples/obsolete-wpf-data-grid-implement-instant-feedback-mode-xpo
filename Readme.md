# WPF Data Grid - Implement the Instant Feedback Mode (XPO)

In this example, the Data Grid is bound to an [XPInstantFeedbackSource](https://docs.devexpress.com/XPO/DevExpress.Xpo.XPInstantFeedbackSource) object that activates an [Instant Feedback Mode](https://docs.devexpress.com/WPF/6279/controls-and-libraries/data-grid/bind-to-data/server-mode-and-instant-feedback). In this mode, you will no longer experience any UI freezing. The Data Grid performs data operations asynchronously in a background thread to make your application highly responsive.

## Files to Look At

* [DataModel.cs](./CS/InstantFeedbackMode/DataModel.cs) (VB: [DataModel.vb](./VB/InstantFeedbackMode/DataModel.vb))
* [MainWindow.xaml](./CS/InstantFeedbackMode/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/InstantFeedbackMode/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/InstantFeedbackMode/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/InstantFeedbackMode/MainWindow.xaml.vb))

## More Examples

The following example shows how to bind the WPF Data Grid to different data sources: [Bind the WPF Data Grid to Data](https://github.com/DevExpress-Examples/how-to-bind-wpf-grid-to-data).

This example includes multiple solutions that demonstrate:

* How to bind the Data Grid to Entity Framework, EF Core, and XPO.
* Different binding mechanisms: virtual sources, server mode sources, and local data.
* MVVM and code-behind patterns.

After you bind the Data Grid to a database, you can implement CRUD operations (create, read update, delete). View Example: [Implement CRUD Operations in the WPF Data Grid](https://github.com/DevExpress-Examples/how-to-implement-crud-operations).
