//this function has responsibility make transportation of data from server to page
function requestApi(data) {

    if (data != null) {

        //Check if exists the property
        if (data.hasOwnProperty('url') &&
            data.hasOwnProperty('method')) {

            var xhttp = new XMLHttpRequest();

            xhttp.onreadystatechange = function () {
                if (this.readyState == 4 && this.status == 200) {

                    if (data.hasOwnProperty('command')) {
                        let execut = data['command'];
                        let response = xhttp.responseText;
                        execut(response);
                    }
                }
            };

            xhttp.load = function () {

            }

            xhttp.open(String(data['method']).toUpperCase(), String(data['url']).toLowerCase(), true);
            xhttp.send();
        }
    }
}


//This function has responsibility to write on page
function loadPage(data) {

    if (data != null) {

        let pageelemnt = document.getElementById('content');

        if (pageelemnt != null) {

            pageelemnt.innerHTML = '';

            let obj = JSON.parse(data);

            for (var i = 0; i < obj.length; i++) {

                let iten = obj[i];
                let id = iten['objectId'];
                let company = iten['company']['name'];
                let origin = iten['origin'];
                let destination = iten['destination'];
                let departureDate = iten['departureDate']['iso'];
                let price = iten['price'];
                let busClass = iten['busClass'];
                let scr = iten['imageSrc'];
                let currency_price = price.toLocaleString('pt-br', { style: 'currency', currency: 'BRL' });


                let element_a = document.createElement("hr");
                element_a.className = 'featurette-divider';


                let element_b = document.createElement("span");
                element_b.className = 'text-muted';
                element_b.innerText = String(currency_price);


                let element_c = document.createElement("h3");
                element_c.className = 'featurette-heading';
                element_c.appendChild(element_b);


                let element_d = document.createElement("p");
                element_d.className = 'lead';
                element_d.innerText = 'De ' + String(origin) + ' para ' + String(destination);


                let element_e = document.createElement("div");
                element_e.className = 'col-md-10 order-md-2';
                element_e.appendChild(element_c);
                element_e.appendChild(element_d);


                let element_f = document.createElement("div");
                element_f.className = 'col-md-2 order-md-1';
                element_f.innerHTML = '<img class="bd-placeholder-img bd-placeholder-img-lg featurette-image img-fluid mx-auto" width="300" height="300" src="' + String(scr) + '" focusable="false">';


                let element_g = document.createElement("div");
                element_g.className = 'row featurette';
                element_g.appendChild(element_a);
                element_g.appendChild(element_e);
                element_g.appendChild(element_f);


                pageelemnt.appendChild(element_g);

            }
        }
    }
}

//This function has responsibility to fill element select
function loadDropdown(data) {

    if (data != null) {

        let pageelemnt = document.getElementById('filter_class');

        if (pageelemnt) {

            pageelemnt.innerHTML = '';

            let obj = JSON.parse(data);

            for (var i = 0; i < obj.length; i++) {

                let iten = obj[i];

                var elem = document.createElement('option')
                elem.value = String(iten);
                elem.text = String(iten);

                pageelemnt.add(elem, pageelemnt.options[0]);

            }
        }
    }    
}

//Show message to user.
function messagemShow(value) {

    if (value != null) {

        if (value.hasOwnProperty('title')) {
            document.getElementById('modalmessage_label').innerText = value['title'];
        }
        else {
            document.getElementById('modalmessage_label').innerText = '';
        }

        if (value.hasOwnProperty('messagem')) {
            document.getElementById('modalmessage_text').innerText = value['messagem'];
            document.getElementById('modalmessagem').focus();
        }
    }
}

//Load search
function findTrip() {

    let date = document.getElementById('filter_date');
    let classbus = document.getElementById('filter_class');
    let money = document.getElementById('filter_value');

    if (date != null &&
        classbus != null &&
        money != null) {

        let data_value = date.value;
        let classbus_value = classbus.options[classbus.selectedIndex].text;
        let money_value = money.value;

        let pageelemnt = document.getElementById('content');
        pageelemnt.innerHTML = '';


        var data = {
            method: 'GET',
            url: '/api/Trip/GetParameter?date=' + String(data_value) + '&classbuss=' + String(classbus_value),
            command: function (response) {
                loadPage(response);
            },
        };

        requestApi(data);
    }
}