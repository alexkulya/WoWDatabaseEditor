﻿using ExtensionMethods;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDE.Blueprints.Data;

namespace WDE.Blueprints.Editor.ViewModels
{
    public class BlueprintEditorViewModel : BindableBase
    {
        private BlueprintSolutionItem solutionItem;

        public GraphViewModel GraphViewModel { get; }
        
        private bool showNodePicker;
        public bool ShowNodePicker
        {
            get { return showNodePicker; }
            set { SetProperty(ref showNodePicker, value); }
        }

        public void PickerResponse(NodeDefinition def)
        {
            ShowNodePicker = false;
        }

        public BlueprintEditorViewModel(BlueprintSolutionItem solutionItem, NodesViewModel nodesViewModel)
        {
            this.solutionItem = solutionItem;

            GraphViewModel = new GraphViewModel();
            
            GraphViewModel.RequestNodePickerWindow += async (connection) =>
            {
                //ShowNodePicker = true;
                var window = new Views.NodePickerWindow();
                nodesViewModel.SetCurrentConnectionContext(connection);
                window.DataContext = nodesViewModel;
                await window.ShowDialogAsync();//.ShowDialogCenteredToMouse();
            };

            GraphViewModel.AddElement(new NodeViewModel("Node 1", Enums.NodeType.Event, 0, 3), 10000, 10000);
            GraphViewModel.AddElement(new NodeViewModel("Node 2", Enums.NodeType.Statement, 2, 3), 10100, 10000);
            GraphViewModel.AddElement(new NodeViewModel("Node 3", Enums.NodeType.Expression, 1, 1), 10200, 10000);
            GraphViewModel.AddElement(new NodeViewModel("Node 4", Enums.NodeType.Statement, 4, 1), 10300, 10000);
        }
    }
}
