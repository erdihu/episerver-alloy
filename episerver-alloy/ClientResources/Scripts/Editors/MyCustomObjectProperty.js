define([
        "dojo/_base/declare",
        "dijit/_Widget",
        "dijit/_TemplatedMixin",

        "dojo/text!./templates/MyCustomObjectProperty.html",
        "dojo/dom",
        "dojo/domReady!"
    ],
    function (
        declare,
        _Widget,
        _TemplatedMixin,
        template,
        dom
    ) {
        return declare("alloy/editors/MyCustomObjectProperty", [
                _Widget,
                _TemplatedMixin], {
                templateString: template,
                _onValueChange: function(val) {
                    if (!val.currentTarget.value) {
                        this.value = {};
                    }
                    this.value = JSON.parse(val.currentTarget.value);
                    this._set('value', this.value);
                    this.onChange(this.value);
                },
                _setValueAttr: function (val) {
                    if (val) {
                        var str = JSON.stringify(val);
                        this.value.value = str;
                        this._set('value', str);
                    }
                },
                isValid: function () {
                    return true;
                }
            }
        );
    });