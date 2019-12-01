import React, { Component } from 'react';
import { Glyphicon } from 'react-bootstrap';
import ReactDOM from 'react-dom';
import { Link } from 'react-router-dom';
//import './CSS/Home.css';


export class Home extends Component {
    displayName = Home.name

    constructor(props) {
        super(props)
        this.to = "";
        this.message = "To Scan your vechile's VIN number, please click on the link http://localhost:4000";
        this.sendNotification = this.sendNotification.bind(this);
    }
    componentWillMount() {
        this.getClientData()
    }

    getClientData() {
        var request = new XMLHttpRequest()
        request.addEventListener('load', () => {
            console.log(request.responseText)
        })        
        request.open('GET', 'http://localhost:4000/api/get/clientdata')
        
        request.send()
    }

    sendNotification(to, message) {
        var request = new XMLHttpRequest()
        request.addEventListener('load', () => {
            console.log(request.responseText)
        })
        request.open('GET', 'http://localhost:4000/api/notification/sendsms/' + to + "/" + message)
        

        request.send()
    }



    render() {
        return (

            <div>
                <h1>Start sending out notifications</h1>
                1. display data.
                2. select a user and change to field
                <button onClick={this.sendNotification(this.to, this.message)}>Send Noticicaton</button>

            </div>
        );
    }
}