
# EMDK For Xamarin - Beta v0.5

**Supported**

- Profile Manager Visual Studio Plugin
- Symbol.EMDK.Xamarin APIs
	- EMDKManager, ProfileManager, VersionManager, EMDKBase

**Not Yet Implemented**

- Symbol.EMDK.Xamarin.Barcode - this may be functional, but API names may change
- Xamarin Studio Add-In
- Mac Support


## Visual Studio Setup
In order to use the Profile Manager Wizard with in Visual Studio, you must:

- Manually install the Plug-in.
- Setup Profile files and folders.

> Note: These manual steps are only require for beta. The released version will include an installer that will perform the actions automatically.

### Accessing Needed Files
In order to complete the steps below, you will need to access files referenced that are included with the component. To get access to these files, you will need to add the component to an existing project and then open it's folder

- Either in an existing project or with a new Android project, select **Project/Edit Components**
- Select **Add to project** on the **EMDK For Xamarin** component listed in the **Installed on this machine** section. If you do not see it listed, then please re-install the component.
- After the component has been installed, select the settings button next to it in the **Components** folder of the project and select **Open Containing Folder**
- This should open a folder that contains the extracted version of the component.
- Expand the **component** folder. The **VSplugin** and **Profiles** folders will be used in the following steps.

### 1. Install Visual Studio Plug-in

>Files required for this step are found in the **component/VSplugin** folder of the EMDK For Xamarin component folder

- Exit all the instances of Visual Studio if launched already.
- Run **EMDKProfileManagerWizardVS.vsix** and Accept **Yes** at the **Do you want the following programs to make changes to the computer ?** prompt.
- Select **Install** at the following prompt
- Launch Visual Studio. The EMDK entry should be available in the main menu.
- Click on ‘About EMDK’ to see the product version information.

### 2. Setup Profile file and folders

>Files required for this step are found in the **component/Profiles** folder  of the EMDK For Xamarin component folder

- Create a folder: **C:/Users/Public/Symbol EMDK for Xamarin/**
- Copy the EMDKConfig.txt in this folder **C:/Users/Public/ Symbol EMDK for Xamarin/** 
- Create a folder **C:/Program Files (x86)/Symbol EMDK for Xamarin/**
- Copy the **v3.2** folder to **C:/Program Files (x86)/Symbol EMDK for Xamarin/**

If the files are placed accordingly, EMDK wizard should load without any error and you should see the features list in profile editor.


## Using Profile Manager
###Creating Profiles
In order to access the EMDK Profile Manager Wizard, an Android application project has to be created:

- Open or create an Android Application project. 
- Select the project and click on the entry **EMDK Profile Manager** menu.
- Proceed with creating the profiles as required.

After creating the profile/s and selecting **Close**, the file **EMDKConfig.xml** would be added under the folder **Assets** as an Android asset. To make changes, you may select the project and click on the menu item **EMDK Profile Manager** at any time.


> Note: Clicking on the menu item **EMDK Profile Manager** without selecting any project results in the following message. As mentioned there, please select the project and continue.

For more information about the Profile Manager Wizard, please check the [usage guide]() for more information.

### Using Profiles in your Xamarin Application
After creating profiles, they will be ready to be used within your Xamarin application. Please check the [Profile Manager API tutorial]() for more details.

## More Information
Further documentation including API reference, tutorials and developer guides can be found online at [http://emdk.github.io/xamarin-docs](http://emdk.github.io/xamarin-docs).

## Uninstalling EMDK For Xamarin
Removing the EMDK For Xamarin from your system requires two steps:

- Removing the component
- Removing the Visual Studio Plug-in

### Removing the component
- Open the **Components** folder of the project.
- Select the settings button of the **EMDK For Xamarin**
- Choose **Remove**

>Note: this removes the component from your existing project. To remove it completely from your system, remove the **emdk-component...** folder from **C:/Users/<username>/AppData/Local/Xamarin/Cache/Components**

### Removing the Visual Studio Plug-in
You may uninstall this extension at any time as follows:

- In Visual Studi select **TOOLS / Extensions and Updates**
- Select **EMDK For Xamarin** and choose **Uninstall**
- Select the option to restart Visual Studio in the end for the uninstallation of the extension to take effect.
