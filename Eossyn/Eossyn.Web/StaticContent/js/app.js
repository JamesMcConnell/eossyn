var MessageBox = {
    MessageEventArgs: {},
    Element: {},
    Close: function () {
        $(this.Element).dialog('close');
    },
    GetInputValue: function () {
        var input = $('#MessageBoxInput'); return (input) ? input.val() : '';
    }
};

var MessageBoxDialogType = {
    None: {},
    YesNo: {},
    YesNoCancel: {},
    OkCancel: {},
    Ok: {}
};

function intializeMessageBoxButtons(buttonTranslations) {
    MessageBoxDialogType.YesNo[buttonTranslations['Yes'], buttonTranslations['No']];
    MessageBoxDialogType.YesNoCancel[buttonTranslations['Yes'], buttonTranslations['No'], buttonTranslations['Cancel']];
    MessageBoxDialogType.OkCancel[buttonTranslations['Ok'], buttonTranslations['Cancel']];
    MessageBoxDialogType.Ok[buttonTranslations['Ok']];
}
var PositionType = {
    Top: 1,
    Middle: 2,
    Bottom: 3
};

MessageBox.SetMessage = function (messageEventArgs) {
    MessageBox.MessageEventArgs = messageEventArgs;
    if ($('#MessageBox').length == 0) {
        MessageBox.Element = $('<div id="MessageBox"></div>');
        $(document).append(MessageBox.Element);
    } else {
        MessageBox.Element = $('#MessageBox');
    }

    if (MessageBox.MessageEventArgs.Text) {
        MessageBox.Element.text(MessageBox.MessageEventArgs.Text);
    }

    if (MessageBox.MessageEventArgs.Input) {
        MessageBox.Element.append('<div><textarea id="MessageBoxInput"></textarea></div>');
    }

    switch (MessageBox.MessageEventArgs.PositionType) {
        case PositionType.Top:
            MessageBox.MessageEventArgs.Position = {
                my: 'center top',
                at: 'center top',
                of: window
            };
            break;
        case PositionType.Middle:
        default:
            MessageBox.MessageEventArgs.Position = {
                my: 'center',
                at: 'center',
                of: window
            };
            break;
        case PositionType.Bottom:
            MessageBox.MessageEventArgs.Position = {
                my: 'center bottom',
                at: 'center bottom',
                of: window
            };
            break;
    }
    var buttons = {};
    switch (MessageBox.MessageEventArgs.MessageBoxDialogType) {
        case MessageBoxDialogType.None:
        default:
            break;
        case MessageBoxDialogType.YesNo:
            buttons = MessageBoxDialogType.YesNo;
            buttons['No'] = MessageBox.MessageEventArgs.NegativeResponse;
            buttons['Yes'] = MessageBox.MessageEventArgs.PositiveResponse;
            break;
        case MessageBoxDialogType.YesNoCancel:
            buttons = MessageBoxDialogType.YesNoCancel;
            buttons['Cancel'] = MessageBox.MessageEventArgs.NeutralResponse;
            buttons['No'] = MessageBox.MessageEventArgs.NegativeResponse;
            buttons['Yes'] = MessageBox.MessageEventArgs.PositiveResponse;
            break;
        case MessageBoxDialogType.OkCancel:
            buttons = MessageBoxDialogType.OkCancel;
            buttons['Cancel'] = MessageBox.MessageEventArgs.NeutralResponse;
            buttons['Ok'] = MessageBox.MessageEventArgs.PositiveResponse;
            break;
        case MessageBoxDialogType.Ok:
            buttons = MessageBoxDialogType.Ok;
            buttons['Ok'] = MessageBox.MessageEventArgs.PositiveResponse;
            break;
    }

    MessageBox.Element.dialog(
        {
            autoOpen: false,
            modal: MessageBox.MessageEventArgs.Modal,
            title: MessageBox.MessageEventArgs.Header,
            width: MessageBox.MessageEventArgs.Width,
            height: MessageBox.MessageEventArgs.Height,
            buttons: buttons,
            closeOnEscape: MessageBox.MessageEventArgs.CloseOnEscape,
            draggable: MessageBox.MessageEventArgs.Draggable,
            resizable: MessageBox.MessageEventArgs.Resizable,
            position: MessageBox.MessageEventArgs.Position,
            zIndex: MessageBox.MessageEventArgs.ZIndex,
            beforeClose: function (event, ui) {
                $(this).remove();
            }
        });
    if (!MessageBox.MessageEventArgs.ShowCloseX) {
        $('a.ui-dialog-titlebar-close').remove();
    }
    MessageBox.Element.dialog('open');
    var mbButtons = $('button');
    for (var i = 0; i < mbButtons.length; i++) {
        $(mbButtons[i]).addClass('button');
        $(mbButtons[i]).addClass((i < mbButtons.length - 1) ? 'secondary' : 'primary');
    }
};

var UserTimeoutManager = {};
function initUserTimeoutManager(interval, header, text) {
    UserTimeoutManager.MessageEventArgs =
    {
        Text: text,
        Header: header,
        Modal: true,
        CloseOnEscape: false,
        MessageBoxDialogType: MessageBoxDialogType.YesNo,
        PositiveResponse: function () {
            $.ajax({
                url: '/Account/ExtendSession',
                cache: false,
                success: function (data) {
                    clearTimeout(UserTimeoutManager.MessageBoxTimer);
                    MessageBox.Close();
                }
            });
        },
        NegativeResponse: function () { logout(): }
    };

    UserTimeoutManager.SetTimer = function (timerInterval) {
        clearTimeout(UserTimeoutManager.Timer);
        UserTimeoutManager.Timer = setTimeout(function () {
            if ($.cookie('eossyn_timeout_time') == null || getDateMilliseconds() >= parseInt($.cookie('eossyn_timeout_time'))) {
                MessageBox.SetMessage(UserTimeoutManager.MessageEventArgs);
                UserTimeoutManager.MessageBoxTimer = setTimeout(function () { logout(); }, (30 * 1000));
            } else {
                var ti = getDateMilliseconds() - parseInt($.cookie('eossyn_timeout_time'));
                setTimeoutIntervalCookie(ti);
                UserTimeoutManager.SetTimer(ti);
            }
        }, timerInterval);
    };

    UserTimeoutManager.SetTimer(interval);
}

function logout() {
    $.ajax({
        url: '/Account/Logout',
        cache: false,
        success: function (data) {
            window.location = "";
        }
    });
}

function setTimeoutIntervalCookie(timeoutInterval) {
    $.cookie('eossyn_timeout_time', getDateMilliseconds() + timeoutInterval, { expires: 1, path: '/' });
}

function getDateMilliseconds() {
    var date = new Date();
    var milliseconds = date.getHours() * 60 * 60 * 1000;
    milliseconds = milliseconds + date.getMinutes() * 60 * 1000;
    milliseconds = milliseconds + date.getSeconds() * 1000;
    milliseconds = milliseconds + date.getMilliseconds();
    return milliseconds;
}

$(document).ajaxSuccess(function (e, xhr, settings) {
    if (settings.url.search('/Account/GetUserTimeout') == -1 && UserTimeoutManager.SetTimer) {
        $.ajax({
            url: '/Account/GetUserTimeout',
            cache: false,
            success: function (data) {
                var timeoutInterval = parseInt(data) - (45 * 1000);
                UserTimeoutManager.SetTimer(timeoutInterval);
                setTimeoutIntervalCookie(timeoutInterval);
            }
        });
    }
});