import React, { Component } from 'react'
import { Route, Routes } from 'react-router-dom'
import AppRoutes from './AppRoutes'
import { Layout } from './components/Layout'
import { ThemeProvider } from '@mui/material/styles'
import { default as theme } from './theme'
import './custom.css'

export default class App extends Component {
  static displayName = App.name

  render() {
    return (
      <ThemeProvider theme={theme}>
        <Layout>
          <Routes>
            {AppRoutes.map((route, index) => {
              const { element, ...rest } = route
              return <Route key={index} {...rest} element={element} />
            })}
          </Routes>
        </Layout>
      </ThemeProvider>
    )
  }
}
