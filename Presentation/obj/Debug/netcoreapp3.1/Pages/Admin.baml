   M S B A M L   `   `   `  ����G  CPresentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Presentation.PagesPresentation.Pages  5      A%clr-namespace:Presentation.ViewModelsPresentation.ViewModels  5          Presentation.Pages.Admin   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Presentation.Pages     5      4vm%clr-namespace:Presentation.ViewModels     5        N� Title$
  Home��5
       � DataContext 5      ,   &Presentation.ViewModels.AdminViewModel  5   
   .��5      �    BgColor#���   6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $
��Left=�6.   $	��800��6I   $��50��6U   $	��Top=�6a   .+�5      ��   ButtonTemplate#��[ 67   $	��400��6c   $��Refresh��6o   ��6   �� *GoHomeCommand+6o   �� 5      $	��400��67   #��[ 6C   $��Log Out��6n   ��6   �� *LogOutCommand+6n   5      �� 5   
   $��0,50,0,0q�6   $	��Top=�6&     
ErrorColor#���  6>    �� TextAlignment$ Center=�6h   $��25(�6   ��6�   �� *ErrorMessage+�� 5   
   #���   6   $	��400��69   $��0,100,400,0q�6E   $	��Top=�6Z   $	��350��6r   $��0��6   ��6�   �� *	Resumes+ �� SelectedItem 5      �� *SelectedResume+��5      �� 5      .R�5      �� $��5q�6!     BgTextBoxColor#���  6,   .+�5      �� $��16(�6$   $	��300��62   $
��Wrap=�6>   $ Center=�6R   ��6j   ��  �� Path$ ShortDescription��� 5      $
��Wrap=�6$   $	��300��68   ��6D   �� $ FullDescription�5      5      5      �� 5    
     RoundedButtonTemplate#��[ 6   $��100,460,0,0q�6C   $
��Left=�6X   $	��150��6s   $��20��6   $��Delete Item��6�   ��6�   �� *DeleteItemCommand+�� 5!   
   $	��350��6   $	��Top=�6   $��400,100,0,0q�67   $��0��6L   #���   6\   ��6�   �� *	Vacancies+ 5"      �� *SelectedVacancy+��5#      �� 5$      .R�5%      �� $��5q�6!   #���  6,   .+�5&      �� $��16(�6$   $ Center=�62   $	��300��6I   ��6U   �� $ ShortDescription��� 5'      $	��300��6$   ��60   �� $ FullDescription�5(      5)      5+      �� 5,   
   #��[ 6   $��500,460,0,0q�6C   $
��Left=�6X   $	��150��6s   $��20��6   $��Delete User��6�   ��6�   �� *DeleteUserCommand+5-      5.      