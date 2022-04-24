# Rules Based Alerting System
 Rule Based Alerting System is a desktop application that provides all the relevant services for hospital staff to remotely monitor all patients and their vitals in the ICU.
 
 ## WorkFlow
 This Application has the following features: 
 1. Patient Registration
 2. Patient Report
 3. ICU Bed Layout
 4. Patient Discharge
 
 When the patient is being admitted to the ICU, the patient's details is entered in the Patient registration page and the bed number is alloted through the services.
 
 Whenever a patient is added, an examcard of that respective patient will be generated on the top view panel. User will be able to see the details of the respective patient in the Patient report page, and the bed allotted will be changed to Orange colour in the bed layout page.
 
 If the user presses start exam in the patient report page, the vitals(SPO2,Temperature,Pulse Rate) will be sent from the service, and the respective comments for each range of vitals will be displayed beside the vitals. The graph will be generated for all the three vitals in realtime. The respective bed will be turned to Green and the vitals for the current bed will be displayed realtime in the bed column.
 
 Whenever a vital crosses the threshold, an alert will be generated. It will be reflected in the bed layout page where the respective bed's colour changes to Red. After medical inspection of the vitals, user will be able to reset the alert of the respective patient. (The bed's colour will be changed to Green)
 
 After all the process, once the patient is free to be discharged, User can be able to enter the patient ID ( or choose from the top panel examcards) and click discharge to discharge the patient from the ICU. The bed which was allocated to that patient will turn gray and it the status becomes "Vacant".
 
 
### For more details, refer the CaseStudy2API.docx


