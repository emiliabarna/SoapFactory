   M S B A M L   `   `   `  ����F  BSoapFactory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:SoapFactorySoapFactory  5   	       SoapFactory.SoapStock   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:SoapFactory     5   	   -   5          � Title$  	SoapStock��5	   	   $	��300��6   $��628.8��6(   .��5      ]� .+�5   
   � $��Bottom=�6    � ColumnDefinitions 5      �� 5      6%   �� 5      6%   �� 5      6%    � RowDefinitions 5      �� 5      6"   �� 5      6"   .+�5      �� -   5         ��Name$ btnBack��5      $��0��6&   $��0��66   $��2��6C   .��6j   Vissza6r   �� 5      -   5        $ btnNew��5      $��1��6%   $��0��65   .��6W   Új szappan felvétele6m   �� 5      -   5        $ 	btnDelete��5      $��2��6(   $��0��68   .��6]   
Törlés6e   �� 5      -   5        $ 	btnModify��5      $��1��6(   $��1��68   .��6]   Módosítás6h   �� 5      -   5        $ btnSave��5      $��2��6&   $��1��66   .��6a   	Mentés6i   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ SoapstockDataGrid��5         AutoGenerateColumns .     CanUserAddRows .     SelectionUnit$ FullRow=�5          
IsReadOnly . ���	#FF79D7A6	   Columns	 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn
   Header$

 Név��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   ��  �� Path$
 Name�6R     5$      -   5        
SoapRecipe��$
 Recept��5$   9    6I   �� $ RecipeTable.Name�6u     5%      $
 Gyártási idő��6%    6;   �� $ TimeOfProduction�   myDateVisualizerConverter �� 	Converter# [  6�     5&      $
 Felhasználható��6%    6=   �� $ TimeOfReadyToUse�# [  6�     5'      $
 Lejárat��6%    66   �� $ BestBeforeDate�# [  6�     5(      $
 Készlet��6%    66   �� $ InStock�6Y     5)      $
 Ár/db��6%    64   �� $ Price�6U     5*      $
 Megjegyzés��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 69    6E   �� $ Others�6g   5,      5-      5/      