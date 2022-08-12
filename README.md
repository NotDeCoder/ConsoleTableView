# ConsoleTableView
___
_This is my first github project. In it, I tried to make a convenient class for input / output of data tables.\
The key difference from all similar projects is that in this table the elements are centered in each cell_
### "Create-Add-Show"
Here I created a table, assigned titles to it, added elements and displayed it in the console

````csharp
TableOfData showTable = new TableOfData("Name", "Age", "Height", "Weight");
            
showTable.AddRow("Kim Min Yang", "101", "180", "80");
showTable.AddRow("Dorkiva Albel Rovo De Gusto Bret IV", "9", "95", "40");
showTable.AddRow("Czech Lorem Ipsum", "30", "165", "58");
showTable.AddRow("Firr Din Tos", "16", "176", "76");
            
showTable.Show();
````
Result of the program:\
<br/>
![Oops.. something wrong. I can't show you an image of the results](https://user-images.githubusercontent.com/94294950/184317100-333543de-96d7-4610-b3c1-11113fbd3a86.png)

<br/><br/>


### Numeration
You can turn on the numbering of elements in the table. The output will create a new column where the row index will be shown

````csharp
showTable.ShowWithNumeration();
````
Result of the program:\
<br/>
![Oops.. something wrong. I can't show you an image of the results](https://user-images.githubusercontent.com/94294950/184317413-cb1bde98-4d81-425b-a9f5-ccb2337d5c01.png)

<br/><br/>

### Delete Element
You can remove an element (row) from a table

````csharp
showTable.DeleteRow(1);
showTable.ShowWithNumeration();
````
Result of the program:\
<br/>
![Oops.. something wrong. I can't show you an image of the results](https://user-images.githubusercontent.com/94294950/184317843-b56eb5c1-a276-448f-ac74-98eadf86d2e0.png)

<br/><br/>

### Spaces in cells
You can change the number of spaces for cells. I also showed here another option for outputting a table to the console

````csharp
showTable.SetSpacesOfColumn(5);
Console.WriteLine(showTable.GetTableAsString());
````
Result of the program:\
<br/>
![Oops.. something wrong. I can't show you an image of the results](https://user-images.githubusercontent.com/94294950/184318023-b7b9b98a-1c4f-405c-bc96-3b7862fdeff8.png)
___
### Total output
Here I combined all of the above to show the total output to the console
```` csharp
TableOfData showTable = new TableOfData("Name", "Age", "Height", "Weight");
            
showTable.AddRow("Kim Min Yang", "101", "180", "80");
showTable.AddRow("Dorkiva Albel Rovo De Gusto Bret IV", "9", "95", "40");
showTable.AddRow("Czech Lorem Ipsum", "30", "165", "58");
showTable.AddRow("Firr Din Tos", "16", "176", "76");

showTable.Show();
showTable.ShowWithNumeration();

showTable.DeleteRow(1);
showTable.ShowWithNumeration();

showTable.SetSpacesOfColumn(5);
Console.WriteLine(showTable.GetTableAsString());
````
Total result of the program:\
<br/>
![Oops.. something wrong. I can't show you an image of the results](https://user-images.githubusercontent.com/94294950/184318891-9cd0913e-e952-4123-9851-4971c1c2cdfc.png)
<br/><br/>
For now, that's all. I will try to refine this project in the near future. Have a good use
