   M S B A M L   `   `   `  ����F  BFestivalApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:FestivalApp.ViewModelFestivalApp.ViewModel  5   	   3clr-namespace:FestivalApp.ViewFestivalApp.View  5   	       FestivalApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   2vm#clr-namespace:FestivalApp.ViewModel     5   	   ,vclr-namespace:FestivalApp.View     5   	     � Title$  
MainWindow��5   	   $	��768��6   $
��1024��6*    � DataContext 5      )  #FestivalApp.ViewModel.ApplicationVM  5   
    � 	Resources 5
       �� DataType&   FestivalApp.ViewModel.MainPageVM   FestivalApp.View.MainPage$  FestivalApp.ViewModel.TicketVM   FestivalApp.View.Ticket,  &FestivalApp.ViewModel.ContactpersoonVM%   FestivalApp.View.Contactpersoon*  $FestivalApp.ViewModel.InstellingenVM#	   FestivalApp.View.Instellingen#
  FestivalApp.ViewModel.BandsVM   FestivalApp.View.Bands   MijnMenuTemplate��%�  (��       5      *, +)(�� 7     5      *, +)(�� n     5      *, +)(�� �     5      *, +)(�� �     5      *,
 +)&	      �� 5   
   "  6   .R�5        6   5      �� 5   
   "  6   .R�5        6   5      �� 5   
   "  6   .R�5        6!   5      �� 5   
   "  6   .R�5      	  6   5      �� 5   
   " 
 6   .R�5        6   5      �� 5      .R�5      � 5      5      .��5      �  � RowDefinitions 5   
   �� 5       $��30 �6   �� 5!      $��* �6   .+�5#   
   �� #��[  65   ��6   �� *Pages+��5$      �� 5%      .R�5&      �� $��4q�5'   X   $	��100��6c   ��5&   #   �� *Name+��6<   �� *DataContext.ChangePageCommand+ �� RelativeSource ��  �� AncestorType" ���5'   o   �� 5(      5*      �� 5+   
   $��1��6   ��6&   �� *CurrentPage+5,      5-      