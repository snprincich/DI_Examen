   M S B A M L   `   `   `  ����>  :WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:WPF.ViewWPF.View  5      -clr-namespace:WPF.ViewModelWPF.ViewModel  5	          WPF.View.RegistroView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:WPF.View     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      A =Wpf.Ui, Version=3.0.5.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  5      ,
viewmodelsclr-namespace:WPF.ViewModel  5	      $	��412��5      $	��801��6   .��5      � $��Center=�6   $��Center=�6&     � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5!      $
��Auto �6   �� 5#      $
��Auto �6   �� 5%      $
��Auto �6   .+�5*   
   �� $��Registro de Usuario��5+      $��28(�5,      $��SemiBold"�5-      
���   �$��Center=�5/      $��0��50      �� 53   
   $��Nombre Completo��6   $��1��54      
���   �$	��Top=�56      $
��Left=�57      $��14(�58       J� IsHitTestVisible$ False��59        Wpf.Ui.Controls.TextBox  5;   
   
����������#4A90E2$��1q�5>   #   $
��10,5q�67   $��14(�6F   $��2��6T   ��5=      �� *Name+ �� Mode$ TwoWay=�.��5>   a    J� Effect 5?      3  -System.Windows.Media.Effects.DropShadowEffect  5@         Color$ Black��6#      	Direction$	 270Q�61      
BlurRadius$ 5Q�6A      ShadowDepth$ 2Q�6P   .��5A   !   5B      �� 5E   
   $��Nombre de Usuario��6   
���   �$	��Top=�5G      $
��Left=�5H      $��14(�5I      $ False��5J      $��3��5K        5L   
   
����������#4A90E2$��1q�5O   #   $
��10,5q�67   $��14(�6F   $��4��5P      ��5N      �� *
UserName+$ TwoWay=�.��5P       5Q        5R      $ Black��6#   $	 270Q�61   $ 5Q�6A   $ 2Q�6P   .��5S   !   5T      �� 5W   
   $��Correo Electrónico��6   
���   �$	��Top=�5Y      $
��Left=�5Z      $��14(�5[      $ False��5\      $��5��5]        5^   
   
����������#4A90E2$��1q�5a   #   $
��10,5q�67   $��14(�6F   $��6��5b      ��5`      �� *Email+$ TwoWay=�.��5b       5c        5d      $ Black��6#   $	 270Q�61   $ 5Q�6A   $ 2Q�6P   .��5e   !   5f      �� 5i   
   $��Contraseña��6   
���   �$	��Top=�5k      $
��Left=�5l      $��14(�5m      $ False��5n      $��7��5o      !  Wpf.Ui.Controls.PasswordBox  5p   
   
����������#4A90E2$��1q�5s   #   $
��10,5q�67   $��14(�6F   $��8��5t         Password 5r      �� *
Password+$ TwoWay=�.��5t       5u        5v      $ Black��6#   $	 270Q�61   $ 5Q�6A   $ 2Q�6P   .��5w   %   5x        Wpf.Ui.Controls.Button  5{   
   $��Registrarse��5}      
���   �
�������$	��200��5�      $��50��5�      $��10,10,10,10q�5�      $��Center=�5�      $	��Top=�5�      $��9��5�      	   CornerRadius$	 25��5�      $��16(�5�      ��5|      �� *RegistroCommand+$ OneWay=�
   Icon
 5~      '  !Wpf.Ui.Markup.SymbolIconExtension     Symbol$ Add20=� 5�        5�      $ Black��6#   $	 270Q�61   $ 10Q�6A   $ 4Q�6Q   5�      �� 5�   
   $(��"Already have an account? Login now��6   $��Center=�6>    � Cursor$
 Hand��6[   
����  �$��10��6{   $��10,10,10,10q�6�    J� InputBindings 5�      d� 5�       d� Gesture$ 	LeftClicka�6    �� Command 63   �� *ToLoginPageCommand+5�      5�      5�      