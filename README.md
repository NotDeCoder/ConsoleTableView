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


### Add row in required index
Insert your row at the index of your choice

````csharp
tableOfStudents.InsertRow(2, "Do Re Mi", "40", "167", "55" );
tableOfStudents.ShowWithNumeration();
````
Result of the program:\
<br/>
![Oops.. something wrong. I can't show you an image of the results](https://user-images.githubusercontent.com/94294950/184480451-a7cb676b-1049-48ba-9864-279ff4d2b632.png)


<br/><br/>


### Change one element of table
If you know element`s row and column, you can change it

````csharp
tableOfStudents.ChangeElementAt(0, 0, "Row Din Takel");
tableOfStudents.Show();
````
Result of the program:\
<br/>
![Oops.. something wrong. I can't show you an image of the results](https://user-images.githubusercontent.com/94294950/184480585-b3a7494e-52f6-4c63-8f93-bb3e9c02e1cf.png)


<br/><br/>


### Change one element of table #2
If you know element`s row and element`s title, you can change it

````csharp
tableOfStudents.ChangeElementWithRowAndTitle(3, "Age", "18");
tableOfStudents.Show();
````
Result of the program:\
<br/>
![Oops.. something wrong. I can't show you an image of the results](https://user-images.githubusercontent.com/94294950/184480717-8fd7856a-9237-4396-824e-e7df4a9a6945.png)


<br/><br/>


### Change the whole row 
If you know the row index, you can change/replace it

````csharp
tableOfStudents.ChangeRow(2, new string[] { "Wir Ro Min", "33", "195", "95" });
tableOfStudents.ShowWithNumeration();
````
Result of the program:\
<br/>
![Oops.. something wrong. I can't show you an image of the results](https://user-images.githubusercontent.com/94294950/184480822-f253f672-8de9-401c-9ddc-7143d879c9a7.png)


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

<br/><br/>


### Some more Get Methods
There are two methods for getting a table element by two indices, by index and title. And also a method to get the index of the title

````csharp
Console.WriteLine("Element at 1:0 position: " + tableOfStudents.GetElementAt(1, 0));
Console.WriteLine("Element of 2nd row and \"Name\" column: " + tableOfStudents.GetElementWithRowAndTitle(2, "Name"));
Console.WriteLine("Index of \"Height\" title: " + tableOfStudents.GetIndexOfTitle("Height"));
````
Result of the program:\
<br/>
![Oops.. something wrong. I can't show you an image of the results](https://user-images.githubusercontent.com/94294950/184484638-93e38bd7-b96e-44f1-a9f9-1c42ff554001.png)
___
For now, that's all. I will try to refine this project in the near future. Have a good use
