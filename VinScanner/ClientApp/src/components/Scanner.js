import React, { Component } from 'react';
import BarcodeReader from 'react-barcode-reader';
import { Glyphicon } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import { Col, Grid, Row } from 'react-bootstrap';
import './CSS/Scanner.css';

export class Scanner extends Component {
    displayName = Scanner.name
    constructor(props) {
        super(props)
        this.state = {
            result: 'Make sure the barcode fits within the orange square',
        }
        this.scan = this.scan.bind(this)
    }

    scanning() {
        console.log("Busy scanning")
    }
    //Scan the VIN barcode
    scan(data) {
        this.setState({
            result: "Your VIN number has been successfully scanned and connected"
        })
        console.log("Data: ", data)
        this.showSuccessMessage()

    }

    //Error handling
    handleError(err) {
        console.error(err)
    }

    //Display Success 'pop'
    showSuccessMessage() {
        var successMessageDiv = document.getElementById("scanner-success");
        successMessageDiv.style.display = "block";
    }

    render() {
        return (
            <div>
                <row className="top-header">
                    Scan VIN Number

                        <Link to={'/'}>
                        <Glyphicon glyph='remove' />
                    </Link>
                </row>

                <p>{this.state.result}</p>
                <div className="scan-area" >



                    <div className="scanner-box">
                        <BarcodeReader
                            onError={this.handleError}
                            onScan={this.scan}
                            onReceive={this.scan}
                            displayName="test"
                        />
                    </div>


                </div>

                <div id="scanner-success" className="scanner-success" >

                    <h1>Success!</h1>
                    <p>Your VIN number has been successfully scanned and connected</p>

                </div>

            </div >
        );
    }
}

