/* eslint-disable no-undef */
import React, { useState, useEffect } from 'react';
import axios from 'axios';

function CustomerList() {
    const [customers, setCustomers] = useState([]);

    useEffect(() => {
        fetchCustomers();
    }, []);

    const API_BASE_URL = process.env.REACT_APP_API_BASE_URL;

    const fetchCustomers = async () => {
        try {
            const response = await axios.get(`${API_BASE_URL}/api/Customer`);
            console.log(response);
            setCustomers(response.data);
        } catch (error) {
            console.error('Error fetching customers:', error);
        }
    };

    return (
        <div>
            <h2>Customer</h2>
            <ul>
                {customers.map((customer) => (
                    <li key={customer.id}>
                        {customer.name} - {customer.address}
                    </li>
                ))}
            </ul>

        </div>
    );
}

export default CustomerList;
