import React, { Component } from 'react';
import { Redirect, Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import Announcements from './components/Announcements';
import Announcement from './components/Announcement';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Announcements} />
        <Route exact path='/anuncios' component={Announcements} />
        <Route path='/novo-anuncio' component={Announcement}/>
        <Route path='/anuncios/:id' component={Announcement}/>
      </Layout>
    );
  }
}
