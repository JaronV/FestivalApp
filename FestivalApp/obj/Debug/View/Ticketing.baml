   M S B A M L   `   `   `  ����F  BFestivalApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:FestivalApp.ViewModelFestivalApp.ViewModel  5          FestivalApp.View.Ticket   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2vm#clr-namespace:FestivalApp.ViewModel     5        � 	Resources  5	         TicketTypeTemplate  BezoekerTemplate  ErrorTemplate  TextboxError �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value  ComboBoxError��%�  &	        &	 �     &	 �     &	 �    &	     �� 5
   
   .R�5      �� .+�5      �� ��6   �� *Name+�� 5      ��6   �� *
kortedatum+5      5      �� 5   
   .R�5      �� .+�5      �� ��6   �� *Ticketholder+5      5      �� 5   
   .R�5      �� .+�5      �� 
���  ����6-   �� *[0].ErrorContent+�� 5      
���  ��$��2q�6+   ._�5      �� 5      5      5      �� 5    
   " ��6%    5!      P� 5"       �@=�HasError . . �5#      ��  � ��
 �  ��63   5$      5&      �� 5'   
   " ��6&    5(      P� 5)       �@=�HasError . . �5*      ��  � ��
 �  ��63   5+      5-      5.      .��5/      �  � DataContext 50   
   $  FestivalApp.ViewModel.TicketVM  51      .+�53   
   �� -   5         ��Name$ Tickettype_toevoeg��53      $��New
��6X   $
��Left=�6p   $��170,251,0,0q�6�   $	��Top=�6�   $��74��6�   $��20��6�   ��6-   �� *AddTickettypeCommand+6�   �� 54   
   -   5        $ Tickettype_verwijder��54      $��Verwijderen��6[   $
��Left=�6q   $��368,251,0,0q�6�   $	��Top=�6�   $��76��6�   ��6/   �� *DeleteTickettypeCommand+6�   �� 55   
   -   5        $ Tickettype_bewerk��55      $��Opslaan��6V   $
��Left=�6h   $��270,251,0,0q�6�   $	��Top=�6�   $��74��6�   ��6,   �� *SaveTickettypeCommand+6�   �� 56   
   -   5        	 ��Name$	 txtVerkrijgbaar��56      $
��Left=�6+   $��22��6F   $��250,170,0,0q�6R   
 �� TextWrapping$

 Wrap=�6g   $	��Top=�6�   $	��120��6�   ��6{   �� *%#SelectedTicketType.AvailableTickets+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 57   
   -   5        $	 txtPrijs��57      $
��Left=�6$   $��23��6?   $��250,126,0,0q�6K   $

 Wrap=�6`    =� ErrorTemplate# [ 59      #��[ 5:      $	��Top=�5;      $	��120��6*   ��58      �� *SelectedTicketType.Price+$ PropertyChanged=� �� ValidatesOnDataErrors . 5;   *   �� 5<   
   -   5        $	 txtSoort��5<      $
��Left=�6$   $��23��6?   $��
250,78,0,0q�6K   $

 Wrap=�6_   # [ 5>      #��[ 5?      $	��Top=�5@      $	��120��6*   ��5=      �� *SelectedTicketType.Name+$ PropertyChanged=� . 5@   *   �� 5A   
   #��[  66   $
��Left=�6�   $	��182��6�   $��	10,74,0,0q�6�   $	��Top=�6�   $	��129��6�   ��6   �� *Tickettypes+ �� SelectedItem 6i   �� *SelectedTicketType+6�   �� 5B   
   $��Tickets��6   $
��Left=�6"   $��	10,10,0,0q�6=   $	��Top=�6P   $��24(�6h   �� 5C   
   $��Festivaltickets��6   $
��Left=�6*   $��10,53.373,0,0q�6E   $	��Top=�6\   �� 5D   
   $��	Bezoekers��6   $
��Left=�6$   $��
10,285,0,0q�6?   $	��Top=�6S   $��24(�6k   �� 5E   
   $
��Naam��6   $
��Left=�6   $��
10,332,0,0q�6:   $	��Top=�6N   �� 5F   
   $��Email��6   $
��Left=�6    $��
10,367,0,0q�6;   $	��Top=�6O   �� 5G   
   $
��Type��6   $
��Left=�6   $��
13,398,0,0q�6:   $	��Top=�6N   �� 5H   
   # [ 5I      #��[ 5J      $
��Left=�68   $��23��6T   $��
89,335,0,0q�6`   $

 Wrap=�6t   $	��Top=�6�   $	��120��6�   ��5H      �� *SelectedTicket.Ticketholder+$ PropertyChanged=� . 5J   �   �� 5K   
   # [ 5L      #��[ 5M      $
��Left=�5N      $��24��6-   $��
89,370,0,0q�69   $

 Wrap=�6M   $	��Top=�6b   $	��120��6z   ��5K      �� *" SelectedTicket.TicketholderEmail+$ PropertyChanged=� . 5N   z   �� 5P   
    �� DisplayMemberPath$
 Name��5Q       �� SelectedValuePath$ ID��5U      # [ 5V      #��[ 5W      $
��Left=�5X      $��
89,402,0,0q�6(   $	��Top=�6<   $	��120��6T   ��5R      �� *Tickettypes+ 5S      �� *SelectedTicket.tickettype+ .  �� SelectedValue 5T      �� *SelectedTicket.tickettype.ID+5X   T   �� 5Y   
   # [ 5Z      #��[ 5[      $
��Left=�5\      $��23��6-   $��
89,438,0,0q�69   $

 Wrap=�6M   $	��Top=�6b   $	��120��6z   ��5Y      �� *SelectedTicket.Amount+$ PropertyChanged=� . 5\   z   �� 5]   
   $	��New��66   $
��Left=�6D   $��
99,502,0,0q�6_   $	��Top=�6s   $��65��6�   ��6   �� *AddTicketCommand+6�   �� 5^   
   $��	Toevoegen��67   $
��Left=�6K   $��170,502,0,0q�6f   $	��Top=�6{   $��75��6�   ��6   �� *SaveTicketCommand+6�   �� 5_   
   $��Verwijderen��69   $
��Left=�6O   $��250,502,0,0q�6j   $	��Top=�6   $��75��6�   ��6   �� *DeleteTicketCommand+6�   �� 5`   
   $��Soort��6   $
��Left=�6    $��
174,78,0,0q�6;   $	��Top=�6O   $��23��6g   $��61��6s   �� 5a   
   $��Prijs��6   $
��Left=�6    $��174,126,0,0q�6;   $	��Top=�6P   $��23��6h   $��61��6t   �� 5b   
   $��Verkrijgbaar��6   $
��Left=�6'   $��171,169,0,0q�6B   $	��Top=�6W   $��23��6o   $��72��6{   �� 5c   
   $
 Date��5d       �� ItemStringFormat$ 
dd/MM/yyyy��6,   # [ 5g      #��[ 5h      $
��Left=�5i      $��250,203,0,0q�6/   $	��Top=�6D   $	��120��6\   $��22��6h   ��5c      �� *UniekeDagen+ 5e      �� *SelectedTicketType.Datum+ . 5i   h   �� 5j   
   -   5        $��lsvReserveringen��5j   +   $��395,328,17,246q�6   $
��Auto=�6�   ��6C   �� *	Tickets+ �� Mode$ TwoWay=� 6p   �� *SelectedTicket+ �� View 5k      �� 5l      .P�5m      �� $
��Naam��6%    �� Width$	 150��6f    �� DisplayMemberBinding 63   ��  �� Path$ Ticketholder�6f   �� 5n      $��Email��6%   $	 100��6l    64   �� $ TicketholderEmail�6l   �� 5o      $��Aantal��6%    65   �� $ Amount��� 5p      $
��Type��6%   $	 100��6i    63   �� $ tickettype.Name�6i   �� 5q      $��Datum��6%   $	 210��6l    64   �� $ tickettype.Datum�6l   5u      5w      �� 5x   
   $��Aantal��6   $
��Left=�6!   $��
13,438,0,0q�6<   $	��Top=�6P   $��24��6h   $��50��6t   �� 5z   
   $��Export Word��68   $
��Left=�6N   $��
99,560,0,0q�6i   $	��Top=�6}   $	��110��6�   $��20��6�   ��6   �� *PrintTicketCommand+6�   �� 5{   
   $��Bewerk��67   $
��Left=�6H   $��232,560,0,0q�6c   $	��Top=�6x   $��74��6�   ��6   �� *EditTicketCommand+6�   �� 5|   
   $��Bewerk��6;   $
��Left=�6L   $��476,251,0,0q�6g   $	��Top=�6|   $��74��6�   ��6   �� *EditTicketTypeCommand+6�   5~      5      