   M S B A M L   `   `   `  ����>  :WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:WPF.ViewWPF.View  5      -clr-namespace:WPF.ViewModelWPF.ViewModel  5	          WPF.View.DashboardView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:WPF.View     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      A =Wpf.Ui, Version=3.0.5.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  5      ,
viewmodelsclr-namespace:WPF.ViewModel  5	      $	��804��5      $	��441��6"   .��5      �   � RowDefinitions  5   
   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   �� -   5        $	��Add��5      $��0��6   $	��Add��6)   $
��Left=�67   $��25(�6r   $��10q�6�   ��6R   �� *
AddCommand+6�   �� 5   
   -   5        $��Delete��5      $��0��6   $��Delete��6,   $��Right=�6=   $��25(�6{   $��10q�6�   ��6Y   �� *DeleteCommand+6�     Wpf.Ui.Controls.DataGrid  5   
   -   5          Name$ 
MyDataGrid��5      $��1��5      &   System.Windows.Controls.DataGrid   AutoGenerateColumns$
 True��5      $��0,0,0,10q�5          CanUserResizeColumns$
 True��5!         CanUserResizeRows$ False��5"      $	��Top=�5#      $��Stretch=�5$         MinRowHeight$ 25Q�5%      $	��400��5&         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 5'      $
��Auto=�5)      $
��Auto=�5*         SelectionMode$ Single=�5,      ��5      �� *PagedFerrari+ �� SelectedItem 5+      �� *FerrariSeleccionado+	 �� Mode$	 TwoWay=�5.      �� 50   
   
 �� Orientation$
 
Horizontal=�6   $��2��6.   $��Center=�6;   $��0,10,0,0q�6X   .+�51      �� $��Anterior��6   
���   �
�������$
��10,0q�6w   ��6(   �� *PreviousPageCommand+6w   �� 52      
���**��$��Center=�6h   $
��10,0q�6�   ��6   �� *CurrentPageView+ �� StringFormat$ 
Pagina {0}��6�   �� 53      $��/��6   $��Center=�6!   �� 54      
���**��$��Center=�6\   $
��10,0q�6w   ��6   �� *
TotalPages+$
  {0}��6w   �� 55      $��	Siguiente��6   $
��10,0q�6M   
���   �
���������6)   �� *NextPageCommand+6o   56      �� 57   
   $��Save All��6   $
��10,0q�6J   
�������$
��Left=�6l   $��2��6�   ��6$   �� *SaveToFileCommand+6�   58      59      