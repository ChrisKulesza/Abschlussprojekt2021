/**
 * 
 * Description.                 The function sends a post request to the post handler passed in the code behind and executes the context-related method.
 * 
 * @param {any} grid            Syncfusion Datagrid Id
 * @param {any} args            object passed to the function
 * @param {string} posthandler  Posthandler method in the code behind, e.g. for OnPostDelete -> Delete
 */
function syncfusionSendToPostHandler(grid, args, postHandler) {
    // here we are making an ajax call to server  
    var ajax = new ej.base.Ajax({
        // trigger the necessary PostHandler in the code behind
        url: `/Index?handler=${postHandler}`,
        type: "POST",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify({ value: args.rowData })
    });
    ajax.beforeSend = function (xhr) {
        ajax.httpRequest.setRequestHeader("XSRF-TOKEN",
            $('input:hidden[name="__RequestVerificationToken"]').val());
    }

    // sending the request
    ajax.send();
    ajax.onSuccess = function (data) {
        // on the success event we are showing the data returned from server  
        //alert(data);
        // refreshin data grid after successfully removed or duplicated the dataset
        grid.refresh();
    };
}

/* Modal window - Partial View */
/**
 * 
 * Description.         Calls Modal Window partial View located in Pages.Shared.ModalView
 * 
 * */
//function modalWindowDelete(grid, args, postHandler) {
function modalWindowDelete() {
    var ajax = new ej.base.Ajax('/Shared/modalviewdelete', 'GET', true);
    ajax.send().then(function (result) {
        var partialElem = document.getElementById('PartialView');
    partialElem.innerHTML = result;
    var scriptElm = partialElem.querySelectorAll('script')
    for (var i = 0; i < scriptElm.length; i++) {
        eval(scriptElm[i].innerHTML);
        }
    });
}

/**
 * 
 * Description.         Gets the Type of the clicked command icon and return the value as a string.
 * 
 * @param {any} args
 */
function getCommandColumnType(args) {
    let type = args.commandColumn.type;
    return type;
}

/**
 * Custom cross-site scripting
 * 
 * Description.              Preventing cross-site scripting (XSS)
 * 
 * @param {any} args
 */
function beforeSanitizeHtml(args) {
    args.helper = (value) => {
        args.cancel = true;
        var temp = document.createElement('div');
        temp.innerHTML = value;
        var scriptTag = temp.querySelector('script');
        if (scriptTag) {
            ej.base.detach(scriptTag);
        }
        return temp.innerHTML;
    }
}