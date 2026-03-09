developer.mozilla.com

codepen.io

https://entitycode.com

https://emmet.io/
 




vscode-icons  add this extension in vs code 

Live Server add this extension also in vs code by going into extesnion section 


<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body >
  <marquee> <h1>The Main heading</h1></marquee>
  <h1>The main heading</h1>
<h2>The main heading</h2>
<h3>The main heading</h3>
<h4>The main heading</h4>
<h5>The main heading</h5>
<h6>The main heading</h6>
<!--<h7> The main heading</h7> comment is written in this manner -->
  <p align="right"> Lorem ipsum dolor sit amet consectetur adipisicing elit.
     Fugiat blanditiis voluptates eius, libero commodi consequuntur 
     illum odit necessitatibus beatae? Maxime.</p>
     <p align="left">
        Lorem ipsum dolor sit amet consectetur, adipisicing elit. 
        Aspernatur optio totam inventore?
     </p>
     <div align="center">
        Lorem ipsum dolor sit amet consectetur adipisicing elit. 
        Ducimus quam sunt quos laborum, ab ut molestiae asperiores
         impedit accusantium aliquid debitis omnis, nulla libero
          optio distinctio. Quam, explicabo minima. <b>Nemo eaque at perspiciatis</b>
           dolorem molestiae eveniet itaque fugit animi. Consequuntur sapiente 
           ducimus, dolore, repellat, optio minus nostrum nobis amet odit non
            nemo quidem ut cupiditate?
     </div>
</body>
</html>


----------------------------------------------list demo ---------------
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=<device-width>, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <ul>
        <li>Flowers
        <ul>
            <li>Daffodils</li>
            <li>Rose</li>
            <li>Lilly</li>
        </ul>
        </li>
        <li>Fruits
        <ul>
            <li>Apple</li>
            <li>Banana</li>
            <li>grapes</li>
        </ul>
        </li>
    </ul>
</body>
</html>

----------------------------list demo 2-----------
    <!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=<device-width>, initial-scale=1.0">
    <title>Document</title>
</head>

<body>
    <ol>
        <li>Flowers
            <ol>
                <li>Daffodils</li>
                <li>Rose</li>
                <li>Lilly</li>
            </ol>
        </li>
        <li>Fruits
            <ol>
                <li>Apple</li>
                <li>Banana</li>
                <li>grapes</li>
            </ol>
        </li>
    </ol>
</body>

</html>
-----------------list demo 3-----------
    <!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=<device-width>, initial-scale=1.0">
    <title>Document</title>
</head>

<body>
    <ol>
        <li>Flowers
            <ol>
                <li type=A>Daffodils</li>
                <li type=A>Rose</li>
                <li type=A>Lilly</li>
            </ol>
        </li>
        <li>Fruits
            <ol>
                <li type=i>Apple</li>
                <li type=i>Banana</li>
                <li type=i>grapes</li>
            </ol>
        </li>
    </ol>
</body>

</html>
---------------------------------------list demo 4------------------

    <!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=<device-width>, initial-scale=1.0">
    <title>Document</title>
</head>

<body>
    <ol>
        <li>Flowers
            <ol>
                <li type=A>Daffodils</li>
                <li type=A>Rose</li>
                <li type=A>Lilly</li>
            </ol>
        </li>
        <li>Fruits
            <ol>
                <li type=i>Apple</li>
                <li type=i>Banana</li>
                <li type=i>grapes</li>
            </ol>
        </li>
    </ol>
    <ol start="6">
<li> six</li>
<li>seven</li>

    </ol>
</body>

</html>
-----------------------------------------lis demo 5 ---------------------
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=<device-width>, initial-scale=1.0">
    <title>Document</title>
</head>

<body>
    <ul>
        <li type="circle">Flowers
            <ul>
                <li type="disc">Daffodils</li>
                <li type="disc">Rose</li>
                <li type="disc">Lilly</li>
            </ul>
        </li>
        <li type="circle">Fruits
            <ul>
                <li type="square">Apple</li>
                <li type="square">Banana</li>
                <li type="square">grapes</li>
            </ul>
        </li>
    </ul>
</body>

</html>

--------------------------pre tag usage --------------

    <!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=<device-width>, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <pre>
          humpty                  Dumpty 

                sat on the wall 


                The Kings men could not 




                put them together 


    </pre>
</body>
</html>
-------------------------------using tables --------------------------

    Using Tables 
-------------
Apart from grouping the related data into lists,there is another way to control the display of text on a web page using tables.We can use tables to display data in tabular format completely in the form of rows and columns.
Table  tags and  properties :
----------------------------
<tr>  tag is used for starting a new row 
<th> tag is referred as heading of the table 
<td> refers to table data and it determines number of columns in the table
<caption> tag is used to give some title to the table
border :This property provides lining between elements 
cellspacing:refers to spacing between the cells
cellpadding: refers to space between borders of table cells
width : refers to spreading table according to the percentage mentioned
rowspan : to merge rows in table
colspan: to merge columns in table

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <table border="2" width="80%" cellpadding="8" cellspacing="3" bgcolor="lightyellow">
     
      <caption>Student table </caption>
      <!--cell padding means inside cell the content is how much it is far away from border -->
      <!--cell spacing  means in between two cells borders what is the distance is measued 
      in cell spacing -->
     <tr>
        <th>StudentID</th>
        <th>StudentName </th>
        <th>Course</th>
     </tr>
          
        <tr>
            <td align="center">101</td>
            <td align="center">pavan kumar</td>
            <td align="center">Java</td>
        </tr>
        <tr>
            <td align="center">102</td>
            <td align="center">suresh kumar</td>
            <td align="center">C#</td>
        </tr>

        <tr>
            <td align="center">103</td>
            <td align="center">Naveen </td>
            <td align="center">C++</td>
        </tr>
    </table>
</body>
</html>

-------------------merging columns using colspan --------------------

    <!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>

<body>
    <table border="2" width="80%" cellpadding="8" cellspacing="3" bgcolor="lightyellow">

        <caption>Student table </caption>
        <!--cell padding means inside cell the content is how much it is far away from border -->
        <!--cell spacing  means in between two cells borders what is the distance is measued 
      in cell spacing -->

        <!-- want to merge columns studid and name in one -->
        
                <!DOCTYPE html>
                <html lang="en">

                <head>
                    <meta charset="UTF-8">
                    <meta name="viewport" content="width=device-width, initial-scale=1.0">
                    <title>Document</title>
                </head>

                <body>
                    <table border="2" width="80%" cellpadding="8" cellspacing="3" bgcolor="lightyellow">

                       
                        <!--cell padding means inside cell the content is how much it is far away from border -->
                        <!--cell spacing  means in between two cells borders what is the distance is measued 
      in cell spacing -->
                        <!-- merging student id and name using colspan -->
                        <tr>
                            <th colspan="2">StudentID,StudentName</th>

                            <th>Course</th>
                        </tr>

                        <tr>
                            <td colspan="2" align="center">101,pavan kumar</td>

                            <td align="center">Java</td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">102,suresh kumar</td>

                            <td align="center">C#</td>
                        </tr>

                        <tr>
                            <td colspan="2" align="center">103,kiran reddy</td>

                            <td align="center">C++</td>
                        </tr>
                    </table>
                </body>

                </html>



    ---- using row span -------------


<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>

<body>
    <table border="2" width="80%" cellpadding="8" cellspacing="3" bgcolor="lightyellow">

        <caption>Student table </caption>
        <!--cell padding means inside cell the content is how much it is far away from border -->
        <!--cell spacing  means in between two cells borders what is the distance is measued 
          in cell spacing -->
        <tr>
            <th>StudentID</th>
            <th>StudentName </th>
            <th>Course</th>
        </tr>

        <tr>
            <td rowspan="2"  align="center">101</td>
            <td align="center" colspan="2">pavan kumar</td>
        </tr>
        <tr>
            <td align="center" colspan="2">Java</td>
        </tr>
        <tr>
            <td align="center">102</td>
            <td align="center">suresh kumar</td>
            <td align="center">C#</td>
        </tr>

        <tr>
            <td align="center">103</td>
            <td align="center">Naveen </td>
            <td align="center">C++</td>
        </tr>
    </table>
</body>

</html>

    ----------------------------------final code row span--------------------------

    note here when ever i say row span it means that row will occupy two rows and in one row already name is there so for third column i have to create another row seperate 
    and to maintain spacing i need to ....use col span as well so check by using not putting colspan and see the deisng and then use it so this is the final desingn
    <!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>

<body>
    <table border="2" width="80%" cellpadding="8" cellspacing="3" bgcolor="lightyellow">

        <caption>Student table </caption>
        <!--cell padding means inside cell the content is how much it is far away from border -->
        <!--cell spacing  means in between two cells borders what is the distance is measued 
          in cell spacing -->
        <tr>
            <th>StudentID</th>
            <th>StudentName </th>
            <th>Course</th>
        </tr>

        <tr>
            <td rowspan="2" align="center">101</td>
            <td align="center" colspan="2">pavan kumar</td>
        </tr>
        <tr>
            <td align="center" colspan="2">Java</td>
        </tr>
        <tr>
            <td rowspan="2" align="center">102</td>
            <td colspan="2" align="center">suresh kumar</td>
        </tr>
        <tr>
            <td colspan="2" align="center">C#</td>
        </tr>

        <tr>
            <td rowspan="2" align="center">103</td>
            <td colspan="2" align="center">Naveen </td>
        </tr>
        <tr>
            <td colspan="2" align="center">C++</td>
        </tr>
    </table>
</body>

</html>


