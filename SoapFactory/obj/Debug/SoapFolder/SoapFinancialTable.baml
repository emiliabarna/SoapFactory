   M S B A M L   `   `   `  ����F  BSoapFactory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:SoapFactorySoapFactory  5   	   $    SoapFactory.SoapFinancialTable   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:SoapFactory     5   	   -   5          � Title$  SoapFinancialTable��5   	   $	��300��6$   $	��400��61   .��5	      ]� .+�5
   
   � $��Bottom=�6    � ColumnDefinitions 5      �� 5      6%   �� 5      6%   �� 5      6%    � RowDefinitions 5      �� 5      6"   .+�5      �� -   5         ��Name$ btnBack��5      $��0��6&   $��0��66   $��2��6C   .��6j   Vissza6r   �� 5      -   5        $ btnNew��5      $��1��6%   $��0��65   $��19��6W   $��	0.4,0,0,0q�6c   $	��Top=�6v   .��6�   Új szappan eladása6�   �� 5      -   5        $ btnSave��5      $��2��6&   $��0,0,-0.4,0.2q�6T   .��6j   	Mentés6r   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ SoapFinDataGrid��5         AutoGenerateColumns .     CanUserAddRows .     SelectionUnit$ FullRow=�5         
IsReadOnly . ���	#FF79D7A6	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Sorszám��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   ��  �� Path$ TransactionNumber�6c     5      $
 Eladás ideje��6%    6;   �� $
 Date�   myDateVisualizerConverter �� 	Converter# [  6�     5      $
 Szappan neve��6%    6;   �� $ SoapTable.Name�6e     5       $
 
Darabszám��6%    68   �� $ Quantity�6\     5!      $
 Eladási ár��6%    69   �� $ SellingPrice�6a     5"      $
 	Nyereség��6%    67   �� $ Profit�6Y   5$      5%      5&      