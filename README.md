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
showTable.AddRow("Czech Lorem Ipsun", "30", "165", "58");
showTable.AddRow("Firr Din Tos", "16", "176", "76");
showTable.Show();
````
Result of the program:\
<br/>
![Oops.. something wrong. I can't show you an image of the results](https://user-images.githubusercontent.com/94294950/184145226-837fd72e-9fe8-4390-8e4a-89e10b8ee94f.png)

<br/><br/>

### Delete Element
You can remove an element (row) from a table

````csharp
showTable.DeleteRow(1);
showTable.Show();
````
Result of the program:\
<br/>
![Oops.. something wrong. I can't show you an image of the results](https://user-images.githubusercontent.com/94294950/184146276-f9c433f5-400e-43b3-b61c-3258b45ccd43.png)

<br/><br/>

### Spaces in cells
You can also change the number of spaces for cells

````csharp
showTable.DeleteRow(1);
showTable.SetSpacesOfColumn(5);
showTable.Show();
````
Result of the program:\
<br/>
![Oops.. something wrong. I can't show you an image of the results](https://user-images.githubusercontent.com/94294950/184146540-e27636d2-b3ad-4f73-b7cf-e2fcd9da01ed.png)
___
Total result of the program:\
<br/>
![Oops.. something wrong. I can't show you an image of the results](https://user-images.githubusercontent.com/94294950/184152052-15f901e4-496f-4338-98e3-2aaaac9382dc.png)
<br/><br/>
For now, that's all. I will try to refine this project in the near future. Have a good use
