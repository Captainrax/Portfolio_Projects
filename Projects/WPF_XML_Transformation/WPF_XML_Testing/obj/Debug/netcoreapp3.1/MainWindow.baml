   M S B A M L   `   `   `  ����J  FWPF_XML_Testing, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WPF_XML_TestingWPF_XML_Testing  5   	        WPF_XML_Testing.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WPF_XML_Testing     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � -   5        $��MainwindowGrid��5	   E   $��Stretch=�6   $��Stretch=�6'    � ColumnDefinitions 5
   
   �� 5      $	��150 �6   �� 5      $	��50* �6    � RowDefinitions 5   
   �� 5      $��27 �6   �� 5      $��27 �6   �� 5      $��27 �6   �� 5      $��27 �6   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $��27 �6   �� 5      $��27 �6   �� 5      $��27 �6   �� 5      $��27 �6   .+�5   
   �� -   5        $��BtnXML��5   H   $��0��6   $��0��6   $��4q�6.   $	��XML��69   6Y   �� 5   
   -   5        $��SelectedXML��5   0   $��0��6   $��1��6    �� 
IsReadOnly$
 True��6C   �� 5   
   -   5        $��BtnXSLT��5   I   $��1��6   $��0��6   $��4q�6.   $
��XSLT��69   6[   �� 5    
   -   5        $��SelectedXSLT��5    0   $��1��6   $��1��6   $
 True��6D   �� 5!   
   -   5        $��BtnTransform��5!   R   $��2��6   $��2��6   $��4q�62   $��	Transform��6=   6i   �� 5"   
   -   5        $��BtnLoad��5"   [   $��3��6   $��0��6   $��4q�6/   $��Load Transformed File��6:   6m   �� 5#   
   -   5        $��
BtnLoadRaw��5#   i   $��3��6   $��1��6   $��4q�6/   $)��#Load Raw XML (XML2/TechCollege.xml)��6:   6~   &   System.Windows.Controls.DataGrid  5%   
   -	   5        $��XMLGrid��5%   4   $��4��6   $��2��6    6E     5&   
   -
   5        $��XMLGrid2��5&   4   $��5��6   $��2��6    6F   �� 5(   
   -   5        $��SaveText��5(   0   $��6��6   $��0��6   $
 True��6@   �� 5)   
   -   5        $��BtnSave��5)   I   $��6��6   $��1��6   $��4q�6/   $
��Save��6:   6X   �� 5*   
   -   5        $��
BtnXML_XSD��5*   H   $��7��6   $��0��6   $��4q�6.   $	��XML��69   6]   �� 5+   
   -   5        $��SelectedXML_XSD��5+   0   $��7��6   $��1��6   $
 True��6G   �� 5,   
   -   5        $��BtnXSD��5,   H   $��8��6   $��0��6   $��4q�6.   $	��XSD��69   6Y   �� 5-   
   -   5        $��SelectedXSD��5-   0   $��8��6   $��1��6   $
 True��6C   �� 5.   
   -   5        $��BtnValidate��5.   M   $��9��6   $��0��6   $��4q�6.   $��Validate��69   6c   �� 5/   
   -   5        $��ValidateResult��5/   0   $��9��6   $��1��6   $
 True��6F   50      51      