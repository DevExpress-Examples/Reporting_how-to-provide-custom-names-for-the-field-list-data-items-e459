# How to provide custom names for the Field List data items


<p>This example demonstrates how to use the <strong>IDisplayNameProvider </strong>interface (which substituted the <strong>IDataDictionary </strong>interface starting with the 11.2 XtraReports version) to change the names of the Field List items shown in both the Visual Studio and End-User report designers. </p><p>This example shows implementation of the <strong>IDisplayNameProvider</strong> interface for the <strong>System.Data.DataSet </strong>class, which allows the Field List to automatically retrieve the custom names from a data source that implements this interface.</p><p>See also:<br />
- <a href="https://www.devexpress.com/Support/Center/p/E667">Best Practices of Implementing the IDataDictionary Interface for a Business Object</a>;<br />
- <a href="https://www.devexpress.com/Support/Center/p/E2706">How to provide custom icons for the Field List in the End-User Designer</a>.</p>

<br/>


