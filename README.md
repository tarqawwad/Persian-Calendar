# Persian-Calendar 
- White theme for Persian Calendar , easy to use.
- Create Persian Calendar as html helper.
- Use Tag builder in c# for build html helper (MVCHtmlString).
- Convert selected persian date to gregorian date.
- Cannot allow to edit on inputs. 
- Create Random ID for Inputs and Calendar. 


# Options 

- (string) componentName : name is applied on gregorian date ( when get value for component name , return gregorian date ).
- (Datetime) value : set value for calendar.
- (object) htmlattribute : Add custom attributes to the input that is used for the calendar.
- (string) onChange : Apply any script on change the value on Calendar such as function(){ //any thing } .
- (bool) IsRequired : Are you date is required ? true or false . 
- (Datetime) minValue : Select minimum value for calendar . 
- (Datetime) maxValue : Select maximum value for calendar . 


# How to use 

- add component namespace "<add namespace="PersianCalendarComponents.Components" />" to "Views/Web.config" 
- call DatePicker from any View such as : 

@Html.TADatePicker(componentName,value, htmlattribute,onChange, IsRequired, minValue, maxValue)

