function BrowseServer(inputId) {
    var finder = new CKFinder();
    finder.BasePath = '/Plugin/ckfinder/';
    finder.SelectFunction = SetFileField;
    finder.SelectFunctionData = inputId;
    finder.Popup();
}

function SetFileField(fileUrl, data) {
    $("#ContentPlaceHolder_txtImgURL").val(fileUrl);
    sessionStorage["ImageURL"] = fileUrl.substring(fileUrl.lastIndexOf('/') + 1, fileUrl.length);
    $('#ContentPlaceHolder_imgProduct').attr('src', '../../Img/images/' + fileUrl.substring(fileUrl.lastIndexOf('/') + 1, fileUrl.length))
}

function SetImgControl() {
    $("#ContentPlaceHolder_txtImgURL").val('/Admin/Img/images/' + sessionStorage["ImageURL"]);
    $('#ContentPlaceHolder_imgProduct').attr('src', '../../Img/images/' + sessionStorage["ImageURL"])
}

$(() => {
    var isReloadImg = sessionStorage["ReloadImg"];
    if (isReloadImg != null && isReloadImg == "true") {
        SetImgControl();
    }

})