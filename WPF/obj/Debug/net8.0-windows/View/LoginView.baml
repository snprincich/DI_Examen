   M S B A M L   `   `   `  ����>  :WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:WPF.ViewWPF.View  5      -clr-namespace:WPF.ViewModelWPF.ViewModel  5	          WPF.View.LoginView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:WPF.View     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      A =Wpf.Ui, Version=3.0.5.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  5      ,
viewmodelsclr-namespace:WPF.ViewModel  5	      -   5        $	��434��5      $	��789��6   .��5      � $��Center=�6   $��Center=�6&     � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��Inicio de Sesión��5       $��28(�5!      $��SemiBold"�5"      
���   �$��Center=�5$      $��0,0,0,20q�5%      $��0��5&      �� 5)   
   $��1��5*      $��Center=�5+      $��Center=�5,      $��	0,10,0,20q�5-      .+�5/        Wpf.Ui.Controls.TextBox     PlaceholderText$ Usuario��50      $	��311��51      $��20��52      $��	0,10,0,10q�53      ���#F7F7F7��55      �� *Name+ �� Mode$ TwoWay=�!  Wpf.Ui.Controls.PasswordBox  57      $ Contraseña��58      $	��311��59      $��20��5:      $��	0,10,0,10q�5;      ���#F7F7F7   Password 5=      �� *
Password+$ TwoWay=�5>        Wpf.Ui.Controls.Button  5A   
   $��Iniciar Sesión��5C      $	��180��5D      $��50��5E      
���   �
�������$��Center=�5H      $��Center=�5I         CornerRadius$ 10��5J      $��2��5K      ��5B      �� *LoginCommand+$ OneWay=�5K      �� 5N   
   $��3��5O       �� Orientation$ 
Horizontal=�5P      $��Center=�5Q      $��0,10,0,0q�5R      .+�5T      �� $��¿No tienes una cuenta? ��5U      
�������$��Center=�5W      �� 5Y      ���#4A90E2 � Cursor$
 Hand��5[      $��Center=�5\      �� 5]       �� Command 6   �� *RegisterCommand+.�6@   .�5^      �� $�Regístrate aquí��6   5_      5`      5a      5b      5c      