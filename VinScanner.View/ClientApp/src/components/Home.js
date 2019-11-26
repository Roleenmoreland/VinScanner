import React, { Component } from 'react';
import { Glyphicon } from 'react-bootstrap';
import ReactDOM from 'react-dom';
import { Link } from 'react-router-dom';
import './CSS/Home.css';


export class Home extends Component {
    displayName = Home.name

    render() {
        return (

            <div>
                <h1>Ready to</h1>

                <h2>Scan your VIN</h2>
                <p>
                    Click on the camera icon below to scan the VIN number on your vechicle's license plate
                </p>
                
                <Link to={'/scanner'}>
                    <Glyphicon glyph='camera' />
                </Link>
            </div>
        );
    }
}