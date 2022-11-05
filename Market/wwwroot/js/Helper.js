function ShowImage(act) {
    $(ImgContainer).empty()
    var fileList = act.files;
    for (var i = 0; i < fileList.length; i++) {

        var t = window.URL || window.webkitURL;
        var objectUrl = t.createObjectURL(fileList[i]);
        $('#ImgContainer').append(`
        <div class="col-4 gap-1 mt-2 imgEdit">
            <img id="NewImg" src="${objectUrl}" class="img-product-size bd-placeholder-img card-img-top" style="width:150px; height:100px;" />
        </div>
        `);

    }

}