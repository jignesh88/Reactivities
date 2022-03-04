import React, { useState, useEffect } from 'react';
import './App.css';
import axios from "axios";
import { Button, List, ListItem, ListItemText } from '@mui/material';

interface activity {
  id: string;
  title: string;
}

function App() {

  const [ activities, setActivities ] = useState([]);

  useEffect(() => {
    axios('http://localhost:5001/activities').then(response => {
      setActivities(response.data);
    })
  }, []);

  return (
    <div className="App">
      <List>
      { activities.map((item:activity) =>
          <ListItem>
            <ListItemText primary={item.title}></ListItemText>
          </ListItem>
      )}
      </List>
    </div>
  );
}

export default App;
