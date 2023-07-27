import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Header, List, ListItem } from 'semantic-ui-react';
import { Activity } from '../models/activity';

function App() {

  const [activites, setActivies] = useState<Activity[]>([]);

  useEffect(() => {
    axios.get<Activity[]>('http://localhost:5000/api/activities')
      .then(response => {
        setActivies(response.data);
      })
  }, [])

  return (
    <div>
      <Header as='h2' icon='users' content='Reactivities' />
        <List>
          {activites.map((activity) => (
            <ListItem key={activity.id}>{
              activity.title}
            </ListItem>
          ))}
        </List>
    </div>
  );
}

export default App;
