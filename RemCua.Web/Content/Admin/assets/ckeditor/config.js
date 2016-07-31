/*
Copyright (c) 2003-2012, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function( config )
{
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    // config.uiColor = '#AADC6E';
    // Simplify the dialog windows.
    config.removeDialogTabs = 'image:advanced;link:advanced';

    config.filebrowserBrowseUrl = '/Content/Admin/assets/ckfinder/ckfinder.html',
    config.filebrowserUploadUrl = '/Content/Admin/assets/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files',
    config.filebrowserWindowWidth = '1000',
    config.filebrowserWindowHeight = '700'
};
