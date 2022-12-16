import React, { Component } from 'react'
import Button from '@mui/material/Button'
import {
  Collapse,
  Navbar,
  NavbarBrand,
  NavbarToggler,
  NavItem,
  NavLink,
} from 'reactstrap'
import { Link } from 'react-router-dom'
import Logo from './../../images/logo.png'
import './style.css'

export class Header extends Component {
  static displayName = Header.name

  constructor(props) {
    super(props)

    this.toggleNavbar = this.toggleNavbar.bind(this)
    this.state = {
      collapsed: true,
    }
  }

  toggleNavbar() {
    this.setState({
      collapsed: !this.state.collapsed,
    })
  }

  render() {
    return (
      <header id="header">
        <Navbar
          className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow"
          container
          light
        >
          <NavbarBrand tag={Link} to="/">
            <img id="logo" src={Logo} />
          </NavbarBrand>
          <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
          <Collapse
            className="d-sm-inline-flex flex-sm-row-reverse"
            isOpen={!this.state.collapsed}
            navbar
          >
            <ul className="navbar-nav flex-grow">
              <NavItem>
                <NavLink tag={Link} className="text-dark" to="/signup">
                  Cadastre-se
                </NavLink>
              </NavItem>
              <NavItem>
                <NavLink tag={Link} className="text-dark" to="/signin">
                  <Button variant="contained">Entrar</Button>
                </NavLink>
              </NavItem>
            </ul>
          </Collapse>
        </Navbar>
      </header>
    )
  }
}
